
using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System.ComponentModel.Design;

namespace ATframework3demo.PageObjects.NewsFeed
{
    public class NewsFeedPostComment
    {
        public string ID { get; set; }

        public IWebDriver Driver { get; }

        public string Text { get; set; } = "";

        public NewsFeedPostComment(IWebDriver driver = default)
        {
            Driver = driver;
        }

        WebItem SendButton(string postID) => new WebItem($"//div[@id='{postID}']", "выбираем пост по айди");


        public void AddTextToComment(string text)
        {
            var CommentFrame = new WebItem("//iframe", "iframe Поле ввода текста комментария");
            CommentFrame.SwitchToFrame(Driver);
            var inputField = new WebItem("(//body)[1]", "Тело сообщения с текстом");
            inputField.SendKeys(text);
            Text = text;
            WebDriverActions.SwitchToDefaultContent();
        }

        // после отправки объект комментария NewsFeedPostComment отправится в список NewsFeedPost
        public NewsFeedPostComment Send()
        {
            var btnSend = new WebItem("//button[contains(@id, 'lhe_button_submit_blogCommentForm')]", "Кнопка отправки комментария");
            btnSend.Click(Driver);
            Waiters.StaticWait_s(3);
            ID = new WebItem($"(//div[contains(text(), '{this.Text}')]//..//..)[1]", "находим комментарий по тексту").GetAttribute("id");
            
            return this;
        }

        internal bool TextIsCorrect(string text)
        {
            throw new NotImplementedException();
        }
    }
}
