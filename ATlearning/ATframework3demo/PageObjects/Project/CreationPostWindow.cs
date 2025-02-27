using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Project
{
    public class CreationPostWindow
    {
        public CreationPostWindow(IWebDriver driver = default)
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

        public CreationPostWindow ChooseType()
        {
            projectFrame.SwitchToFrame();
            continueBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreationPostWindow();
        }

        public CreationPostWindow Accessibilities(string ProjectName)
        {
            projectFrame.SwitchToFrame();
            var projectNameField = new WebItem(
                "//input[@id='GROUP_NAME_input']",
                "Поле добавления названия проекта");
            projectNameField.SendKeys(ProjectName);
            continueBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreationPostWindow();
        }
        
        public CreationPostWindow Сonfidentiality()
        {
            projectFrame.SwitchToFrame();
            continueBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreationPostWindow();
        }

        public ProjectFeed Members()
        {
            projectFrame.SwitchToFrame();
            continueBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectFeed();
        }
    }
}
