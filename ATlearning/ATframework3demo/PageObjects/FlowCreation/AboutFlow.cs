
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace ATframework3demo.PageObjects.FlowCreation
{
    public class AboutFlow
    {
        public AboutFlow(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Установить дедлайн потока
        /// </summary>
        public AboutFlow SetDeadline(int number)
        {
            var inputDeadline = new WebItem(
                "//div[@data-id='tasks-flow-edit-form-field-planned-time']//input[@type='text']",
                "Поле ввода дедлайна (в днях)");
            inputDeadline.SendKeys(number.ToString());
            return new AboutFlow();
        }

        /// <summary>
        /// Установить название потока
        /// </summary>
        public AboutFlow SetName(string name)
        {
            var inputName = new WebItem(
                "//div[@id='tasks-flow-edit-form-field-name']//input",
                "Поле ввода названия потока");
            inputName.SendKeys(name);
            return new AboutFlow();
        }

        /// <summary>
        /// Нажать кнопку продолжить снизу слайдера
        /// </summary>
        public SettingsFlow ToSettings()
        {
            var continueBtn = new WebItem(
                "//button[@data-id='tasks-wizard-flow-continue']",
                "Кнопка продолжить внизу");
            continueBtn.Click();
            return new SettingsFlow();
        }
    }
}
