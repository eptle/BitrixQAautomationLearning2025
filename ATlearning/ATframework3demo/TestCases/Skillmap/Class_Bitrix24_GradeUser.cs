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
    public class Case_Bitrix24_GradeUser : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создать профиль с двумя компетенциями и аттестовать юзера", homePage => GradeUser(homePage)));
            return caseCollection;
        }

        void GradeUser(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            int[] grades = { 10, 20, 30 };

            var ProfilePage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .ClickOnAddSkillBtn()
                .FillSkillForm(1, skill1, grades)
                .FillSkillForm(2, skill2, grades)
                .InputProfileName(profileName)
                .ClickOnCreateProfileBtn()
                .ClickOnBurger(profileName)
                .CertificateEmployee()
                .SelectUser("Дмитрий")
                .SelectProfile(profileName)
                .GradeUser(new int[] { 1, 2 })
                .ClickOnSertificateBtn();
        }

    }
}