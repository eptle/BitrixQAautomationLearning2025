using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.CRM;
using ATframework3demo.PageObjects.NewsFeed;
using ATframework3demo.PageObjects.SkillMap;
using ATframework3demo.PageObjects.SkillMap.Analytics;
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
            caseCollection.Add(
                new TestCase("Аттестовать юзера трижды (джун, сеньор, миддл) по 1 профилю и посмотреть прогресс сотрудника",
                homePage => GradeUserThrice(homePage)));
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
            string admin = TestCase.RunningTestCase.TestPortal.PortalAdmin.NameLastName;

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
            ProfilePage.SortBy("UPDATED_AT");
            
            // аттестовать каждого из двух сотрудников по каждому профилю
            foreach (string profile in new string[] { profileName1, profileName2 })
            {
                foreach (string username in new string[] { username1, username2 })
                {
                    ProfilePage
                        .ClickOnBurger(profile)
                        .CertificateEmployee()
                        .SelectUser(username)
                        .GradeUser(new int[] { 20 })
                        .ClickOnSertificateBtn()
                        .Toolbar
                        .ClickOnSpecialistProfilesBtn();
                }
            }

            var AllCertification = ProfilePage
                 .Toolbar
                 .ClickOnAnalyticsBtn()
                 .AllAttestations();

            List<string> record = new List<string> {
                     "",
                     "",
                     $"{username1}",
                     $"Дмитрий",
                     $"{profileName1}",
                     "20 (Middle)",
                     "Middle (100%)" };

            bool isRecordExist = AllCertification.IsDataCorrect(record);

            if (!isRecordExist)
                Log.Error($"Записи {String.Join(", ", record)} нет в таблице");

        }

        void GradeUserThrice(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            int[] grades = { 10, 20, 30 };
            string username = "test1";

            var ProfilePage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName)
                .FillSkillForm(1, skill1, grades)
                .ClickOnCreateProfileBtn();

            int[] gradesForAttestation = new int[] { 12, 30, 24 };

            foreach (int grade in gradesForAttestation)
            {
                ProfilePage
                    .ClickOnBurger(profileName)
                    .CertificateEmployee()
                    .SelectUser(username)
                    .GradeUser(new int[] { grade })
                    .ClickOnSertificateBtn()
                    .Toolbar
                    .ClickOnSpecialistProfilesBtn();
            }

            var ProgressPage = ProfilePage
                .Toolbar
                .ClickOnAnalyticsBtn()
                .UsersList()
                .ClickOnBurger(username)
                .UserProgress();

            bool isProgressCorrect = ProgressPage.CheckProgress(profileName, grade: "Middle", skills: new List<string> { skill1 }, scores: new List<int> { 24 });

            if (!isProgressCorrect)
            {
                Log.Error($"На странице Мой прогресс пользователя '{username}' неверные данные");
            }

            Waiters.StaticWait_s(3);
        }
    }
}