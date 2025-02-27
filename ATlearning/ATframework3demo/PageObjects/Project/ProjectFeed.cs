using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Project
{
    public class ProjectFeed
    {
        public ProjectFeed(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public WebItem typeMessageArea { get; } = new WebItem(
            "//span[@class='feed-add-post-micro-title']",
            "Поле Написать сообщение ...");

        public WebItem projectIframe { get; } = new WebItem(
            "//iframe[contains(@src, '/workgroups/group/')]",
                "фрейм проекта");

        /// <summary>
        /// Кликнуть по полю "Написать сообщение..." в ленте проекта
        /// </summary>
        public ProjectFeedPostForm ClickTypeMessageArea()
        {
            projectIframe.SwitchToFrame();
            var typeMessageArea = new WebItem(
                "//div[@id='microoPostFormLHE_blogPostForm_inner']",
                "Поле написания нового сообщения");
            typeMessageArea.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectFeedPostForm();
        }

        /// <summary>
        /// Найти пост в ленте по тексту
        /// </summary>
        public bool FindPostByText(string text)
        {
            projectIframe.SwitchToFrame();
            try
            {
                var textPost = new WebItem(
                    $"//div[text()='{text}']",
                    "Текст поста");
                textPost.InnerText();
            }
            catch
            {
                return false;
            }
            WebDriverActions.SwitchToDefaultContent();
            return true;
        }
    }
}
