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
    public class Case_Bitrix24_CreateProjectAndCreateComment
    {
        public class Case_Bitrix24_CRM : CaseCollectionBuilder
        {
            protected override List<TestCase> GetCases()
            {
                var caseCollection = new List<TestCase>();
                caseCollection.Add(new TestCase("Создание проекта и написание поста в проект", homePage => SeeCommentByOtherUser(homePage)));
                return caseCollection;
            }

            void SeeCommentByOtherUser(PortalHomePage homePage)
            {
                var user1 = new Bitrix24CRMcontacts { Name = "user1_" + HelperMethods.GetDateTimeSaltString() };
                user1.CreateByAPI(TestCase.RunningTestCase.TestPortal);
                string projName = "project_" + HelperMethods.GetDateTimeSaltString();
                string text = "text_" + HelperMethods.GetDateTimeSaltString();

                // создание переменной класса ProjectFeed
                var project = homePage
                    .LeftMenu            // меню слева на главной странице
                    .OpenTasks()         // открыть Задачи и Проекты
                    .CreateProjectBtn()  // навести на кнопку Проекты сверху и нажать на плюсик (создать проект)
                    .ToAccessibilities() // перейти в настройки возможностей проекта
                    .AddName(projName)   // добавить название проекта
                    .ToСonfidentiality() // переход во вкладку конфиденциальность
                    .ToMembers()         // переход во вкладку участники
                    .CreateProject();    // создание проекта

                // создание комментария и перенаправление на вкладку класса ProjectFeed
                var Comment = project
                    .ClickTypeMessageArea() // кликнуть по полю отправки сообщений
                    .AddText(text)          // добавить текст сообщения
                    .Send();                // отправить сообщение

                // проверка того, что комментарий с набранным ранее текстом существует
                bool isCommentExists = Comment.FindPostByText(text);
                if (!isCommentExists)
                {
                    Log.Error($"Поста с текстом '{text}' в проекте '{projName}' не найдено");
                }
            }
        }
    }
}