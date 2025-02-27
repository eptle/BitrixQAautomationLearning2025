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
                string projectName = "project_" + HelperMethods.GetDateTimeSaltString();
                string text = "text_" + HelperMethods.GetDateTimeSaltString();

                var project = homePage
                    .LeftMenu
                    .OpenTasks()
                    .CreateProjectBtn()
                    .ChooseType()
                    .Accessibilities(projectName)
                    .Сonfidentiality()
                    .Members();

                var Comment = project
                    .TypeMessageField()
                    .AddText(text)
                    .Send();
            }
        }
    }
}