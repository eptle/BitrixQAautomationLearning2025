using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Project
{
    public class ProjectFeedPostForm
    {
        public ProjectFeedPostForm(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public WebItem projectIframe { get; } = new WebItem(
            "//iframe[contains(@src, '/workgroups/group/')]",
                "фрейм проекта");

        public IWebDriver Driver { get; }

        public ProjectFeedPostForm AddText(string text)
        {
            projectIframe.SwitchToFrame();
            var textAreaFrame = new WebItem(
                "//iframe[@class='bx-editor-iframe']",
                "Фрейм ввода поста");
            textAreaFrame.SwitchToFrame();
            var textArea = new WebItem(
                "//body[@contenteditable='true']",
                "Текстовая область написания поста");
            textArea.SendKeys(text);
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectFeedPostForm();
        }

        public ProjectFeed Send()
        {
            projectIframe.SwitchToFrame();
            var sendBtn = new WebItem(
                "//span[@id='blog-submit-button-save']",
                "Кнопка отправки поста");
            sendBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectFeed();
        }
    }
}
