using System.Diagnostics;
using atFrameWork2.BaseFramework;
using OpenQA.Selenium;
using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.BaseFramework;

namespace atFrameWork2.SeleniumFramework
{
    public abstract class BaseItem
    {
        public static IWebDriver _defaultDriver = default;
        public static IWebDriver DefaultDriver
        {
            get
            {
                if (_defaultDriver == default)
                {
                    _defaultDriver = TestCase.RunningTestCase.EnvType == TestCaseEnvType.Web
                        ? WebDriverActions.GetNewDriver()
                        : MobileDriverActions.GetNewMobileDriver();
                }

                return _defaultDriver;
            }

            set => _defaultDriver = value;
        }

        protected List<string> XPathLocators { get; set; } = new List<string>();
        public string Description { get; set; }
        public string DescriptionFull { get => $"'{Description}' локаторы: {string.Join(", ", XPathLocators)}"; }

        protected BaseItem(List<string> xpathLocators, string description)
        {
            XPathLocators = xpathLocators;
            Description = description;
        }

        public int DefaultWaitAfterActiveAction_s { get; set; } = 1;

        public void Click(IWebDriver driver = default)
        {
            WaitElementDisplayed(driver: driver);
            PrintActionInfo(nameof(Click));

            Execute((button, drv) =>
            {
                button.Click();
            }, driver);

            Waiters.StaticWait_s(DefaultWaitAfterActiveAction_s);
        }

        /// <summary>
        /// Ждёт пока элемент отобразится на странице
        /// </summary>
        /// <param name="maxWait_s"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public bool WaitElementDisplayed(int maxWait_s = 5, IWebDriver driver = default)
        {
            return WaitDisplayedCommon(driver, maxWait_s, true, "Ожидание отображения элемента " + DescriptionFull);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="maxWait_s"></param>
        /// <param name="waitDirection">Если true то будет ждать пока элемент не станет отображаться, иначе будет ждать пока элемент отображается</param>
        /// <param name="waitDescription"></param>
        /// <returns></returns>
        protected bool WaitDisplayedCommon(IWebDriver driver, int maxWait_s, bool waitDirection, string waitDescription)
        {
            driver ??= DefaultDriver;
            var impWait = driver.Manage().Timeouts().ImplicitWait;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            bool result = Waiters.WaitForCondition(() =>
            {
                bool expectedState = false;

                Execute((el, drv) =>
                {
                    expectedState = el.Displayed == waitDirection;
                }, driver, true);

                return expectedState;
            }, 1, maxWait_s, waitDescription);

            driver.Manage().Timeouts().ImplicitWait = impWait;
            return result;
        }

        /// <summary>
        /// Ввод текста в поле
        /// </summary>
        /// <param name="textToInput"></param>
        /// <param name="driver"></param>
        /// <param name="logInputtedText">Выводить ли введённый текст в лог</param>
        public void SendKeys(string textToInput, IWebDriver driver = default, bool logInputtedText = true)
        {
            WaitElementDisplayed(driver: driver);
            string textToLog = $"'{textToInput}'";
            if (!logInputtedText)
                textToLog = "[логирование отключено]";
            PrintActionInfo($"Ввод текста {textToLog} в элемент");

            Execute((input, drv) => { input.SendKeys(textToInput); }, driver);
            Waiters.StaticWait_s(DefaultWaitAfterActiveAction_s);
        }

        protected void Execute(Action<IWebElement, IWebDriver> seleniumCode, IWebDriver driver, bool throwAtDebug = false)
        {
            driver ??= DefaultDriver;

            try
            {
                foreach (var locator in XPathLocators)
                {
                    IWebElement targetElement = default;
                    int staleRetryCount = 3;
                    bool interceptedHandlerFirstTry = true;

                    for (int i = 0; i < staleRetryCount; i++)
                    {
                        try
                        {
                            targetElement = driver.FindElement(By.XPath(locator));
                            seleniumCode.Invoke(targetElement, driver);
                            break;
                        }
                        catch (WebDriverException ex)
                        {
                            if (ex is NoSuchElementException)
                            {
                                if (locator == XPathLocators.Last())
                                    throw;
                            }
                            else if (ex is StaleElementReferenceException)
                            {
                                if (i == staleRetryCount - 1)
                                    throw;
                                Thread.Sleep(2000);
                                continue;
                            }
                            else if (ex is ElementClickInterceptedException)
                            {
                                if (ex.Message.Contains("helpdesk-notification-popup"))
                                {
                                    new WebItem("//div[contains(@class, 'popup-close-btn')]", "Кнопка закрытия баннера").Click(driver);
                                    if (interceptedHandlerFirstTry)
                                        i++;
                                    interceptedHandlerFirstTry = false;
                                    continue;
                                }
                                else
                                    throw;
                            }
                            else
                                throw;
                        }

                        break;
                    }

                    if (targetElement != default)
                        break;
                }
            }
            catch (Exception e)
            {
                if (throwAtDebug || !EnvironmentSettings.IsDebug)
                    throw;
                Debug.Fail(e.ToString());
            }
        }

        protected void PrintActionInfo(string actionTitle)
        {
            Log.Info($"{actionTitle}: " + DescriptionFull);
        }
    }
}
