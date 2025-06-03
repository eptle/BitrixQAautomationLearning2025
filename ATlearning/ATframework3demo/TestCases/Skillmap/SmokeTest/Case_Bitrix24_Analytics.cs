using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using ATframework3demo.BaseFramework;

namespace ATframework3demo.TestCases.Skillmap.SmokeTest
{
    public class Case_Bitrix24_Analytics : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("Просмотр таблицы на страницы 'Статистика по профилям'",
                homePage => Create2ProfilesAndCertificate2UsersTwice(homePage)));

            return caseCollection;
        }

        void Create2ProfilesAndCertificate2UsersTwice(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName1 = "QA Engineer " + date;
            string profileName2 = "PHP developer " + date;
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            int[] grades = { 10, 20, 30 };
            string username1 = "test1";
            string username2 = "test2";
            int[] scores = { 20, 30 };

            var ProfilePage = homePage
                .GoToSkillmap();

            Waiters.StaticWait_s(1);

            // создаем два профиля специалиста
            foreach (string profile in new string[] { profileName1, profileName2 })
            {
                ProfilePage
                    .ClickOnAddProfileBtn()
                    .InputProfileName(profile)
                    .FillSkillForm(1, skill1, grades)
                    .ClickOnAddSkillBtn()
                    .FillSkillForm(2, skill2, grades)
                    .ClickOnCreateProfileBtn();
            }

            // аттестовать каждого из двух сотрудников по каждому профилю
            foreach (string profile in new string[] { profileName1, profileName2 })
            {
                for (int i = 0; i < 2; i++)
                {
                    string[] usernames = new string[] { username1, username2 };
                    ProfilePage.IsDataCorrect(new List<string> { "", profile });
                    ProfilePage
                        .ClickOnBurger(profile)
                        .CertificateEmployee()
                        .SelectUser(usernames[i])
                        .GradeUser(new int[] { scores[i], scores[i] })
                        .ClickOnSertificateBtn()
                        .Toolbar
                        .ClickOnSpecialistProfilesBtn();
                }
            }

            var AllCertification = ProfilePage
                 .Toolbar
                 .ClickOnAnalyticsBtn()
                 .StatByProfiles();

            List<string> record1 = new List<string> { $"{profileName1}", "0", "1", "1", "2" };
            List<string> record2 = new List<string> { $"{profileName2}", "0", "1", "1", "2" };

            bool isRecordExist1 = AllCertification.IsDataCorrect(record1);
            bool isRecordExist2 = AllCertification.IsDataCorrect(record2);

            if (!isRecordExist1)
                Log.Error($"Записи {String.Join(", ", record1)} нет в таблице");
            if (!isRecordExist2)
                Log.Error($"Записи {String.Join(", ", record2)} нет в таблице");

        }
    }
}
