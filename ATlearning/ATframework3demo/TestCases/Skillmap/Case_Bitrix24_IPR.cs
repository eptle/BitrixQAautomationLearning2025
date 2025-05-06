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
            caseCollection.Add(new TestCase("Формирование ИПР для сотрудника и проверка отображения в задачах", homePage => CreateIPR(homePage)));
            caseCollection.Add(new TestCase("Взаимодействие с ИПР через задачу и проверка статуса его выполнения", homePage => StatusIPR(homePage)));
            caseCollection.Add(new TestCase("Формирование двух ИПР и их просмотр в списке ИПР", homePage => ListIPRview(homePage)));
            return caseCollection;
        }
        void CreateIPR(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "Data Scientist " + date;
            string employeeName = "test1";
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            string deadline = "2025-12-31T23:59";
            int[] grades = { 10, 20, 30 };

            var taksPage = homePage
                .GoToSkillmap()
                //создаем профиль специалиста
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName)
                .FillSkillForm(1, skill1, grades)
                .ClickOnAddSkillBtn()
                .FillSkillForm(2, skill2, grades)
                .ClickOnCreateProfileBtn()
                .Toolbar
                .ClickOnIPR()
                //создаем ИПР
                .ClickOnAddIPR()
                .InputProfilAndEmployee(employeeName, profileName)
                .FillDescription("Важно укрепить навыки продвинутого анализа данных, моделирования, оптимизации ML-процессов и развивать компетенции в бизнес-коммуникации и решении прикладных задач.")
                .FillDeadline(deadline)
                .CreateIPR()
                .LeftMenu
                .OpenTasks();

            if (!taksPage.IsIPRtaskExists(profileName))
            {
                Log.Error($"Ипр по профилю '{profileName}' не найден");
            }
        }
        void StatusIPR(PortalHomePage homePage) 
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string profileName = "Data Scientist " + date;
            string employeeName = "test1";
            string skill1 = "Skill_1_ " + date;
            string skill2 = "Skill_2_ " + date;
            string deadline = "2025-12-31T23:59";
            int[] grades = { 10, 20, 30 };

            homePage
                .GoToSkillmap()
                //создаем профиль специалиста
                .ClickOnAddProfileBtn()
                .InputProfileName(profileName)
                .FillSkillForm(1, skill1, grades)
                .ClickOnAddSkillBtn()
                .FillSkillForm(2, skill2, grades)
                .ClickOnCreateProfileBtn()
                .Toolbar
                .ClickOnIPR()
                //создаем ИПР
                .ClickOnAddIPR()
                .InputProfilAndEmployee(employeeName, profileName)
                .FillDescription("Важно укрепить навыки продвинутого анализа данных, моделирования, оптимизации ML-процессов и развивать компетенции в бизнес-коммуникации и решении прикладных задач.")
                .FillDeadline(deadline)
                .CreateIPR()
                .LeftMenu
                //открываем ИПР через задачи и начинаем его
                .OpenTasks()
                .OpenIPR(profileName)
                .BeginIPR()
                .CloseIPR();

            var statIPR = homePage
                .GoToSkillmap()
                .Toolbar
                .ClickOnIPR()
                .ClickOnListIPR();

            if (!statIPR.IsIPRstat(profileName))
            {
                Log.Error("Статус ИПР некорректный");
            }
        }

        void ListIPRview(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
            string[] profileNames = { "Data Scientist " + date, "PHP Developer " + date };
            string[] employeeNames = { "test1", "test2" };
            string[] skills = { "Skill_1_" + date, "Skill_2_" + date };
            string deadline = "2025-12-31T23:59";
            int[] grades = { 10, 20, 30 };

            for (int i = 0; i < employeeNames.Length; i++)
            {
                string profileName = profileNames[i];
                string employeeName = employeeNames[i];

                var allIPRPage = homePage
                        .GoToSkillmap()
                        .ClickOnAddProfileBtn()
                        .InputProfileName(profileName)
                        .FillSkillForm(1, skills[0], grades)
                        .ClickOnAddSkillBtn()
                        .FillSkillForm(2, skills[1], grades)
                        .ClickOnCreateProfileBtn()
                        .Toolbar
                        .ClickOnIPR()
                        .ClickOnAddIPR()
                        .InputProfilAndEmployee(employeeName, profileName)
                        .FillDescription($"Описание для {profileName} (сотрудник: {employeeName})")
                        .FillDeadline(deadline)
                        .CreateIPR();

                if (!allIPRPage.IsIPRlistExists(profileName))
                {
                    Log.Error($"Ипр по профилю '{profileName}' не найден");
                }
            }
        }
    }
}
