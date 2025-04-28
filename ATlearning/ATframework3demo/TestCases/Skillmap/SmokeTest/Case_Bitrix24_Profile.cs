using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.SkillMap;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_Profile : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание и просмотр профиля специалиста (HR, руководитель)", homePage => createProfileAndCheck(homePage)));
            caseCollection.Add(new TestCase("Редактирование профиля специалиста (HR, руководитель)", homePage => editProfile(homePage)));
            return caseCollection;
        }

        void createProfileAndCheck(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_" + date;
            string skill2 = "Skill_2_" + date;
            string skill3 = "Skill_3_" + date;
            int[] grades1 = { 10, 20, 30 };
            int[] grades2 = { 20, 30, 40 };

            var CheckProfile = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName)
                .FillSkillForm(1, skill1, grades1)
                .ClickOnAddSkillBtn()
                .FillSkillForm(2, skill2, grades2)
                .ClickOnAddSkillBtn()
                .ClickOnRemoveSkillBtn(2)
                .ClickOnCreateProfileBtn()
                .ClickOnBurger(profileName)
                .OpenProfile()
                .CheckProfile(profileName, new List<string> { skill1, skill2 }, new List<int[]> { grades1, grades2 });
        }
        void editProfile(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string skill1 = "Skill_1_" + date;
            int[] grades1 = { 10, 20, 30 };
            int[] grades2 = { 20, 30, 40 };

            var CheckProfile = homePage
            .GoToSkillmap()
            .ClickOnAddProfileBtn()
            .InputProfileName(profileName)
            .FillSkillForm(1, skill1, grades1)
            .ClickOnCreateProfileBtn()
            .ClickOnBurger(profileName)
            .EditProfile()
            .InputProfileName("new_" + profileName)
            .FillSkillForm(1, "new_" + skill1, grades2)
            .ClickOnSaveChangesBtn()
            .CheckProfile("new_" + profileName, new List<string> { "new_" + skill1 }, new List<int[]> { grades2 });
        }
    }
}
