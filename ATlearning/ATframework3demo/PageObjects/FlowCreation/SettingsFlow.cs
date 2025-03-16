using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.FlowCreation
{
    public class SettingsFlow
    {
        public SettingsFlow(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Нажать на кнопку "добавить команду" потока
        /// </summary>
        public SettingsFlow AddTeamBtn()
        {
            var addTeamBtn = new WebItem(
                "(//div[contains(@id, 'user_selector')]//span[@class='ui-tag-selector-add-button-caption'])[1]",
                "Кнопка 'Добавить' в распределении 'По очереди'");
            addTeamBtn.Click();
            return new SettingsFlow();
        }

        /// <summary>
        /// Добавить пользователей по Имени и Фамилии
        /// </summary>
        public SettingsFlow AddUserByUsername(List<string> users)
        {
            foreach ( string user in users )
            {
                var addUser = new WebItem(
                    $"//div[contains(@id, 'popup-window-content-popup-window')]//div[contains(text(), '{user}')]",
                    "Добавление нескольких пользователей из всплывающего окна в поток");
                addUser.Click();
            }
            return new SettingsFlow();
        }

        /// <summary>
        /// Нажать кнопку продолжить снизу слайдера
        /// </summary>
        public ControlFlow ToControl()
        {
            var continueBtn = new WebItem(
                "//button[@data-id='tasks-wizard-flow-continue']",
                "Кнопка продолжить внизу");
            continueBtn.Click();
            return new ControlFlow();
        }

        /// <summary>
        /// Нажать по пустой области, чтобы выйти из поп-апа с выбором сотрудников
        /// </summary>
        public SettingsFlow OutOfPopup()
        {
            var outOf = new WebItem(
                "//div[@data-id='tasks-flow-distribution-queue']//div[@class='tasks-flow__create-distribution-type_title-text']",
                "Нажать на заголовок 'По очереди', чтобы выйти из окна");
            outOf.Click();
            return new SettingsFlow();
        }
    }
}
 