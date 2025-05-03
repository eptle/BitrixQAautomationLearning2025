using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.BaseFramework;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_IPR : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Формирование ИПР для сотрудника", homePage => CreateIPR(homePage)));
            caseCollection.Add(new TestCase("Проверка отображения созданного ИПР в задачах", homePage => TaskIPR(homePage)));
            caseCollection.Add(new TestCase("Взаимодействие с ИПР через задачу и проверка статуса его выполнения", homePage => StatusIPR(homePage)));
            caseCollection.Add(new TestCase("Просмотр списка ИПР", homePage => ListIPRview(homePage)));
            return caseCollection;
        }
        void CreateIPR(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "profile_1_" + date;
            string employeeName = "test1";
            string skill1 = "Skill_1_ " + date;
            int[] grades = { 10, 20, 30 };

            var IPRPage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .FillSkillForm(1, skill1, grades)
                .InputProfileName(profileName)
                .ClickOnCreateProfileBtn()
                .Toolbar
                .ClickOnIPR()
                .ClickOnAddIPR()
                .InputProfilAndEmployee(employeeName, profileName)
                .FillDescription()
                .FillDeadline()
                .CreateIPR();
        }
        void TaskIPR(PortalHomePage homePage)
        {

        }
        void StatusIPR(PortalHomePage homePage) 
        {

        }
        void ListIPRview(PortalHomePage homePage)
        {

        }
    }
}
