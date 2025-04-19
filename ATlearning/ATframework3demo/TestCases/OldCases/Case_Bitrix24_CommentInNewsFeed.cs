using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.CRM;
using ATframework3demo.PageObjects.NewsFeed;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_CommentInNewsFeed : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases() // этот метод добавляет наш тест-кейс в очередь/список
        {
            var caseCollection = new List<TestCase>();
            // caseCollection.Add(new TestCase("Создание комментария от другого юзера под постом в ленте", homePage => SeeCommentByOtherUser(homePage)));
            return caseCollection;
        }
        
        void SeeCommentByOtherUser(PortalHomePage homePage)
        {
            var user1 = new Bitrix24CRMcontacts { Name = "user1_" + HelperMethods.GetDateTimeSaltString() };
            user1.CreateByAPI(TestCase.RunningTestCase.TestPortal);
            // выберем первый попавшийся пост из ленты и возьмем его айди
            string postID = new WebItem("(//div[starts-with(@id, 'blg-post-')])[1]", "первый пост в ленте").GetAttribute("id");
            string text = "super_duper_text_" + HelperMethods.GetDateTimeSaltString();
        
            // создаем объект поста
            var post = homePage
            // переходим в новостную ленту
            .NewsFeed
            // выбираем по айди пост в ленте
            .OpenPost(postID);
        
            post.ID = postID;
        
            // тыкаем по полю ввода комментария
            var comment = post.ClickOnCommentArea();
            // добавить текст в комментарий
            comment.AddTextToComment(text);
            // отправить комментарий под постом и получить айди комментария
            string commentID = comment.Send().ID;
        
            // ---------------------------------------
        
            var user2 = TestCase.RunningTestCase.CreatePortalTestUser(false);
        
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
        
            // проверка с другого юзера, что текст комментария не отличается
            string commentText = new PortalLoginPage(TestCase.RunningTestCase.TestPortal)
                .Login(user2)
                .NewsFeed
                // выбираем по айди пост в ленте
                .OpenPost(postID) 
                .GetCommentTextByID(commentID);
        
            if (commentText != text )
            {
                Log.Error("Тексты не совпадают");
            }
        }
    }
}