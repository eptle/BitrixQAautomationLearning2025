
namespace ATframework3demo.PageObjects.NewsFeed
{
    public class NewsFeedPost
    {
        List<NewsFeedPostComment> Comments = new List<NewsFeedPostComment>(); 

        // создается комментарий под постом, добавляется в поле Comments
        public NewsFeedPostComment CreateComment()
        {
            throw new NotImplementedException();
            return new NewsFeedPostComment();
        }

        // выбрать комментарий по айди
        public NewsFeedPostComment ChooseComment(string CommentID)
        {
            throw new NotImplementedException();
            return new NewsFeedPostComment();
        }
    }
}
