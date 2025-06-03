using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.SkillMap;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_AddProfile : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создать профиль с тремя скиллами и редактировать его", homePage => createProfile(homePage)));
            caseCollection.Add(new TestCase("Добавить профиль с одним скиллом и нажать отмена", homePage => cancelCreatingProfile(homePage)));
            caseCollection.Add(new TestCase("Создать профиль с 20-ю скиллами", homePage => createProfileWith20Skills(homePage)));
            return caseCollection;
        }
        void createProfile(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            string skill3 = "Skill_3_ " + date;
            int[] grades = { 10, 20, 30 };

            var ProfilePage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .ClickOnAddSkillBtn()
                .ClickOnAddSkillBtn()
                .FillSkillForm(1, skill1, grades)
                .FillSkillForm(2, skill2, grades)
                .FillSkillForm(3, skill3, grades)
                .ClickOnRemoveSkillBtn(2)
                .InputProfileName(profileName)
                .ClickOnCreateProfileBtn()
                .ClickOnBurger(profileName)
                .OpenProfile();

            ProfilePage.CheckProfile(
                profileName, 
                new List<string> { skill1, skill2 },
                new List<int[]> { grades, grades});

            ProfilePage
                .EditProfile()
                .InputProfileName("new_" + profileName)
                .FillSkillForm(1, "new_" + skill1, new int[] { 1, 2, 3 })
                .ClickOnSaveChangesBtn();

            ProfilePage.CheckProfile(
                "new_" + profileName,
                new List<string> { "new_" + skill1, skill2 },
                new List<int[]> { new int[] { 1, 2, 3 }, grades });
        }

        void cancelCreatingProfile(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_ " + date;
            int[] grades = { 10, 20, 30 };

            var mainPage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .FillSkillForm(1, skill1, grades)
                .InputProfileName(profileName)
                .ClickOnCancelBtn();

            if (mainPage.IsProfileExists(profileName))
            {
                Log.Error($"Профиля {profileName} не должно существовать");
            }
        }

        void createProfileWith20Skills(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_";
            int[] grades = { 10, 20, 30 };

            var profilePage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName);

            for (int i = 1; i <= 20; i++)
            {
                profilePage
                    .FillSkillForm(i, skill1 + $"{i}", grades)
                    .ClickOnAddSkillBtn();
            }
            var mainPage = profilePage
                .ClickOnRemoveSkillBtn(20)
                .ClickOnCreateProfileBtn();

            try
            {
                mainPage.ClickOnBurger(profileName);
            }
            catch (NoSuchElementException)
            {
                Log.Error($"Профиль с именем {profileName} не создался");
            }
        }
    }
}
