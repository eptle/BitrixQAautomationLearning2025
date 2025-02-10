using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.NewsFeed;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        public NewsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public NewsPostForm AddPost()
        {
            //Клик в Написать сообщение
            var btnPostCreate = new WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click(Driver);
            return new NewsPostForm(Driver);
        }

        // выбрать пост в ленте по айди
        public NewsFeedPost OpenPost(string postID)
        {
            var btnPostDate = new WebItem($"//div[@id='{postID}']//div[@class='feed-time']", "Дата, при нажатии на которую открывается пост");
            btnPostDate.Click(Driver);
            return new NewsFeedPost(Driver);
        }
    }
}
