using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.TestEntities;
using static System.Net.Mime.MediaTypeNames;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Flow : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            // caseCollection.Add(new TestCase("Создание потока с распределением задач по очереди (несколько юзеров, проверка грида)", homePage => FlowWithMultipleUsers(homePage)));
            return caseCollection;
        }
        
        void FlowWithMultipleUsers(PortalHomePage homePage)
        {
            string date = HelperMethods.GetDateTimeSaltString();
        
            // создание пользователей с именами username1 и username2
            var user1 = TestCase.RunningTestCase.CreatePortalTestUser(false);
            string username1 = user1.NameLastName;
        
            var user2 = TestCase.RunningTestCase.CreatePortalTestUser(false);
            string username2 = user2.NameLastName;
        
            List<string> users = new List<string> { username1, username2 };
        
            string flowName = "flow_" + date;
            List<string> tasks = new List<string> { "task1_" + date, "task2_" + date }; 
        
            var flowPage = homePage     //
                .LeftMenu                   // левое меню
                .OpenTasks()                // открыть задачи
                .OpenFlows()                // открыть потоки
                .CreateFlowBtn()            // нажать на кнопку "создать поток"
                .SetName(flowName)          // дать имя потоку
                .SetDeadline(1)             // установить время выполения (в днях)
                .ToSettings()               // перейти в настройки проекта
                .AddTeamBtn()               // нажать на кнопку "добавить" в команде потока по очереди
                .AddUserByUsername(users)   // добавить пользователей из массива users
                .OutOfPopup()               // закрыть всплывающее окно со списком пользователей
                .ToControl()                // перейти в "управление" потока
                .CreateFlow();              // нажать на кнопку "создать поток"                 
        
            WebDriverActions.Refresh();
        
            foreach ( string task in tasks )
            {
                flowPage
                .CreateTaskBtn(flowName)    // нажать на кнопку "создать задачу" напротив потока
                .AddTitle(task)             // добавить заголовок задачи
                .CreateTask();              // создать задачу
            }

            var projectPage = flowPage
                .OpenProject(flowName); // открыть проект

            bool isTasksCorrect = projectPage
                .CheckTasks(tasks);     // проверка, что задачи из списка совпадают с созданными

            bool isExecutorsCorrect = projectPage
                .CheckExecutors(users); // проверка, что исполнители заданы правильно

            if (!isTasksCorrect)
            {
                Log.Error("Задания из списка не совпадают с созданными заданиями");
            }

            if (!isExecutorsCorrect)
            {
                Log.Error("Задания из списка не совпадают с созданными заданиями");
            }
        }
    }
}