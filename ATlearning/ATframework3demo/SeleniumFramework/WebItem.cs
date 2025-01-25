using atFrameWork2.BaseFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;


namespace atFrameWork2.SeleniumFramework
{
    public class WebItem : BaseItem
    {
        public WebItem(string xpathLocator, string description) : this(new List<string> {xpathLocator}, description)
        {
        }

        public WebItem(List<string> xpathLocators, string description) : base(xpathLocators, description)
        {
            XPathLocators = xpathLocators;
            Description = description;
        }
        
        /// <summary>
        /// Наведение курсора на объект
        /// </summary>
        /// <param name="driver"></param>
        public void Hover(IWebDriver driver = default)
        {
            PrintActionInfo("Наведение курсора мыши");

            Execute((element, drv) =>
            {
                Actions action = new Actions(drv);
                action.MoveToElement(element).Build().Perform();
            }, driver);

            Waiters.StaticWait_s(DefaultWaitAfterActiveAction_s);
        }

        /// <summary>
        /// Переключение контекста драйвера на заданный iframe
        /// </summary>
        /// <param name="driver"></param>
        public void SwitchToFrame(IWebDriver driver = default)
        {
            PrintActionInfo(nameof(SwitchToFrame));
            Execute((frame, drv) => { drv.SwitchTo().Frame(frame); }, driver);
        }

        /// <summary>
        /// Выбирает элемент списка по его тексту
        /// </summary>
        /// <param name="listItemToSelect">Текст элемента списка</param>
        /// <param name="driver"></param>
        /// <exception cref="Exception"></exception>
        public void SelectListItemByText(string listItemToSelect, IWebDriver driver = default)
        {
            WaitElementDisplayed(driver: driver);
            PrintActionInfo($"Выбор пункта списка '{listItemToSelect}' в списке");

            Execute((select, drv) =>
            {
                var selEl = new SelectElement(select);
                string itemToSelectResultText = default;
                bool optionExists = selEl.Options.ToList().Find(x => x.Text == listItemToSelect) != null;

                if (!optionExists)
                    itemToSelectResultText = selEl.Options.ToList().Find(x => x.Text.Contains(listItemToSelect))?.Text;
                else
                    itemToSelectResultText = listItemToSelect;

                if (itemToSelectResultText != null)
                    selEl.SelectByText(itemToSelectResultText);
                else
                    throw new Exception($"Пункт списка '{listItemToSelect}' не найден в списке {DescriptionFull}");
            }, driver);

            Waiters.StaticWait_s(DefaultWaitAfterActiveAction_s);
        }

        /// <summary>
        /// Показывает отмечен ли чекбокс/элемента списка
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public bool Checked(IWebDriver driver = default)
        {
            WaitElementDisplayed(driver: driver);
            bool isChecked = false;

            Execute((checkBox, drv) => { isChecked = checkBox.Selected; }, driver);

            PrintActionInfo($"Чекбокс {(isChecked ? "отмечен" : "снят")}. Элемент");
            return isChecked;
        }

        /// <summary>
        /// Получает значение произвольного аттрибута элемента по его имени
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public string GetAttribute(string attributeName, IWebDriver driver = default)
        {
            string resultAttrValue = default;

            Execute((el, drv) => { resultAttrValue = el.GetAttribute(attributeName); }, driver);

            PrintActionInfo($"Значение аттрибута {attributeName}='{resultAttrValue}'. Элемент");
            return resultAttrValue;
        }

        /// <summary>
        /// Проверяет наличие заданной подстроки в тексте элемента
        /// </summary>
        /// <param name="expectedText"></param>
        /// <param name="failMessage"></param>
        /// <param name="driver"></param>
        /// <returns>true if expectedText present at element's innerText</returns>
        public bool AssertTextContains(string expectedText, string failMessage, IWebDriver driver = default)
        {
            PrintActionInfo(nameof(AssertTextContains));
            bool result = false;

            Execute((targetElement, drv) =>
            {
                string factText = targetElement.Text;
                result = !string.IsNullOrEmpty(factText) && factText.Contains(expectedText);
            }, driver);

            return result;
        }

        /// <summary>
        /// Получает весь текст, содержащийся в ветке потомков элемента
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public string InnerText(IWebDriver driver = default)
        {
            string elementText = default;

            Execute((targetElement, drv) => { elementText = targetElement.Text; }, driver);

            PrintActionInfo($"Получен текст '{elementText}'. Элемент");
            return elementText;
        }
        

        /// <summary>
        /// Ждёт пока элемент перестанет отображаться на странице
        /// </summary>
        /// <param name="maxWait_s"></param>
        /// <param name="driver"></param>
        /// <returns></returns>
        public bool WaitWhileElementDisplayed(int maxWait_s = 5, IWebDriver driver = default)
        {
            return WaitDisplayedCommon(driver, maxWait_s, false, "Ожидание пропадания элемента " + DescriptionFull);
        }

        /// <summary>
        /// Получает размеры элемента
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="noLog"></param>
        /// <returns></returns>
        public Size Size(IWebDriver driver = default, bool noLog = false)
        {
            Size elementSize = default;

            Execute((targetElement, drv) => { elementSize = targetElement.Size; }, driver);

            if (!noLog)
                PrintActionInfo($"Получен размер '{elementSize}'. Элемент");
            return elementSize;
        }
    }
}
