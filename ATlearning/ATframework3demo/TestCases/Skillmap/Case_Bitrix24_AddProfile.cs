using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.SkillMap;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_AddProfile : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Добавить профиль с тремя скиллами и нажать создать", homePage => createProfile(homePage)));
            caseCollection.Add(new TestCase("Добавить профиль с одним скиллом и нажать отмена", homePage => cancelCreatingProfile(homePage)));
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
                .OpenProfile()
                .CheckProfile(profileName, new List<string> { skill1, skill2 }, new List<int[]> { grades, grades});
        }

        void cancelCreatingProfile(PortalHomePage homePage)
        {

        }

    }
}
