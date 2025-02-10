
using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.NewsFeed
{
    public class NewsFeedPost
    {
        public string ID { get; set; }

        public IWebDriver Driver { get; }

        public NewsFeedPost(IWebDriver driver = default)
        {
            Driver = driver;
        }

        List<NewsFeedPostComment> Comments = new List<NewsFeedPostComment>(); 

        // тыкаем по полю комментария, открываем поле редактирования комментария
        public NewsFeedPostComment ClickOnCommentArea()
        {
            var areaAddComment = new WebItem($"//a[contains(text(), 'Добавить комментарий')]", "Текстовое поле 'Добавить комментарий'");
            areaAddComment.Click(Driver);
            Waiters.StaticWait_s(3);
            return new NewsFeedPostComment(Driver);
        }

        // Найти комментарий по айди и вернуть его текст
        public string GetCommentTextByID(string commentID)
        {
            ID = new WebItem($"//div[@id='{commentID}']/div/div", "находим комментарий по айди").InnerText();
            return ID;
        }
    }
}
