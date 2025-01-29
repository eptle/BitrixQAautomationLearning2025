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
    public class Case_Bitrix24_SeeCommentByOtherUser
    {
        public class Case_Bitrix24_CRM : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases() // этот метод добавляет наш тест-кейс в очередь/список
            {
                var caseCollection = new List<TestCase>();
                caseCollection.Add(new TestCase("Создание сделки", homePage => AddComment(homePage)));
                return caseCollection;
            }

            void AddComment(PortalHomePage homePage)
            {
                var user1 = new Bitrix24CRMcontacts { Name = "user_" + HelperMethods.GetDateTimeSaltString() };
                string postID = "BlogPostSuperID123123";
                string text = "text_" + HelperMethods.GetDateTimeSaltString();

                // создаем объект комментария
                var comment = homePage
                // переходим в новостную ленту
                .ToNewsFeed()
                // выбираем по айди пост в ленте
                .ChoosePost(postID)
                //создаем новый комментарий
                .CreateComment();

                // чтобы не пересоздавать несколько раз один объект, добавим void методы
                // добавить текст в комментарий
                comment.AddText();
                // отправить комментарий под постом
                comment.Send();

                // ---------------------------------------

                var intranetUser = TestCase.RunningTestCase.CreatePortalTestUser(false);
                var extranetUser = TestCase.RunningTestCase.CreatePortalTestUser(true);
                foreach (var user in new[] { intranetUser, extranetUser })
                {
                    var driver2 = WebDriverActions.GetNewDriver();
                    var homePage2 = new PortalLoginPage(TestCase.RunningTestCase.TestPortal, driver2).Login(user);
                    if (!homePage2
                    // переходим в новостную ленту
                    .ToNewsFeed()
                    // выбираем по айди пост в ленте
                    .ChoosePost(postID)
                    // выбираем коментарий по айди
                    .ChooseComment(comment.CommentID)
                    // проверяем корректность написанного текста
                    .TextIsCorrect(text))
                    {
                        Log.Error($"Текст отправленного комментария не совпадает с текстом '{text}', который видит другой пользователь");
                    }
                }
            }
        }
    }
}