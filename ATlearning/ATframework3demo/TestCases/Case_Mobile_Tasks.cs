using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Mobile;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestCases
{
    public class Case_Mobile_Tasks : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("Создание задачи", mobileHomePage => CreateTask(mobileHomePage)));
            return caseCollection;
        }

        void CreateTask(MobileHomePage homePage)
        {
            string taskName = "testTasks" + DateTime.Now.Ticks;
            var testTask = new Bitrix24Task(taskName);

            bool isTaskPresent = homePage.TabsPanel
                .SelectTasks()
                .CreateTask(testTask)
                .IsTaskPresent(testTask);

            if (!isTaskPresent)
            {
                Log.Error($"Созданная задача с названием {taskName} не отображается");
            }
        }
    }
}
