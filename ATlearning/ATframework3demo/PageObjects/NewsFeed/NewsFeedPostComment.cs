

using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.NewsFeed
{
    public class NewsFeedPostComment
    {
        public string CommentText { get; } // если я правильно понимаю, таким образом мы разрешаем пользоваться только геттером
        public string CommentID;

        // добавить текст в комментарий
        public void AddText()
        {
            throw new NotImplementedException();
        }

        // отправить комментарий.
        // После отправки, по моей логике, айди комментария должно помещаться в поле CommentID
        public void Send()
        {
            throw new NotImplementedException();
        }

        // проверить текст и текст в комментарии
        public bool TextIsCorrect(string text)
        {
            throw new NotImplementedException();
            return true; 
        }
    }
}
