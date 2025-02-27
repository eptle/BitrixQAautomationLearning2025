using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Project;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.ProjectCreation
{
    public class AccessibilitiesOfProject
    {
        public AccessibilitiesOfProject(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        public WebItem projectFrame { get; } = new WebItem(
                "//iframe[contains(@src, '/company/personal/user/')]",
                "Фрейм создания проекта");
        public WebItem continueBtn { get; } = new WebItem(
                "//button[@id='sonet_group_create_popup_form_button_submit']",
                "Кнопка продолжить снизу фрейма");

        /// <summary>
        /// Перейти по вкладку "Конфиденциальность"
        /// </summary>
        public СonfidentialityOfProject ToСonfidentiality()
        {
            projectFrame.SwitchToFrame();
            continueBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new СonfidentialityOfProject();
        }

        /// <summary>
        /// Добавить имя проекта
        /// </summary>
        public AccessibilitiesOfProject AddName(string projectName)
        {
            projectFrame.SwitchToFrame();
            var projectNameField = new WebItem(
                "//input[@id='GROUP_NAME_input']",
                "Поле добавления названия проекта");
            projectNameField.SendKeys(projectName);
            WebDriverActions.SwitchToDefaultContent();
            return new AccessibilitiesOfProject();
        }
    }
}
