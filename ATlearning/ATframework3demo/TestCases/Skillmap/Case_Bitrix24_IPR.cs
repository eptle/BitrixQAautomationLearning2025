using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
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
            string profileName = "Data Scientist " + date;
            string employeeName = "test1";
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            int[] grades = { 10, 20, 30 };

            var taksPage = homePage
                .GoToSkillmap()
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName)
                .FillSkillForm(1, skill1, grades)
                .ClickOnAddSkillBtn()
                .FillSkillForm(2, skill2, grades)
                .ClickOnCreateProfileBtn()
                .Toolbar
                .ClickOnIPR()
                .ClickOnAddIPR()
                .InputProfilAndEmployee(employeeName, profileName)
                .FillDescription("Важно укрепить навыки продвинутого анализа данных, моделирования, оптимизации ML-процессов и развивать компетенции в бизнес-коммуникации и решении прикладных задач.")
                .FillDeadline()
                .CreateIPR()
                .LeftMenu
                .OpenTasks();

            if (!taksPage.IsIPRtaskExists(profileName))
            {
                Log.Error($"Ипр по профилю '{profileName}' не найден");
            }
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
