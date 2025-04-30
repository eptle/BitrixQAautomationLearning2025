using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.CRM;
using ATframework3demo.PageObjects.NewsFeed;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.Skillmap.SmokeTest
{
    public class Case_Bitrix24_GradeUser : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создать профиль с двумя скиллами и аттестовать юзера через профиль специалиста", homePage => GradeUserFromMainPage(homePage)));
            caseCollection.Add(
                new TestCase("Создать профиль с одним скиллом и аттестовать юзера через актуальность аттестаций",
                homePage => GradeUserFromCertificationRelevance(homePage)));
            caseCollection.Add(
                new TestCase("Просмотр таблицы всех аттестаций сотрудников",
                homePage => Create2ProfilesAndCertificate2UsersTwice(homePage)));
            return caseCollection;
        }

        void GradeUserFromMainPage(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            int[] grades = { 10, 20, 30 };
            string username = "test1";

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
                .SelectUser(username)
                .SelectProfile(profileName)
                .GradeUser(new int[] { 10, 20 })
                .ClickOnSertificateBtn()
                .CheckCertification(username, "Junior (100%)");
        }

        void GradeUserFromCertificationRelevance(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            int[] grades = { 10, 20, 30 };
            string username = "test1";

            var ProfilePage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .FillSkillForm(1, skill1, grades)
                .InputProfileName(profileName)
                .ClickOnCreateProfileBtn()
                .Toolbar
                .ClickOnAnalyticsBtn()
                .CertificationRelevance()
                .ClickOnBurger(username)
                .CertificateEmployee()
                .SelectUser(username)
                .SelectProfile(profileName)
                .GradeUser(new int[] { 10 })
                .ClickOnSertificateBtn()
                .CheckCertification(username, "Junior (100%)");
        }

        void Create2ProfilesAndCertificate2UsersTwice(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName1 = "profile_1_" + date;
            string profileName2 = "profile_2_" + date;
            string skill1 = "Skill_1_ " + date;
            int[] grades = { 10, 20, 30 };
            string username1 = "test1";
            string username2 = "test2";

            var ProfilePage = homePage
                .GoToSkillmap();

            // создаем два профиля специалиста
            foreach (string profile in new string[] {profileName1, profileName2})
            {
                ProfilePage
                    .ClickOnAddProfileBtn()
                    .FillSkillForm(1, skill1, grades)
                    .InputProfileName(profile)
                    .ClickOnCreateProfileBtn();
            }

            // аттестовать каждого из двух сотрудников по каждому профилю
            foreach (string profile in new string[] { profileName1, profileName2 })
            {
                foreach (string username in new string[] { username1, username2 })
                {
                    ProfilePage
                        .ClickOnBurger(profile)
                        .CertificateEmployee()
                        .SelectProfile(profile)
                        .SelectUser(username)
                        .GradeUser(new int[] { 20 })
                        .ClickOnSertificateBtn()
                        .Toolbar
                        .ClickOnSpecialistProfilesBtn();
                }
            }


        }
    }
}