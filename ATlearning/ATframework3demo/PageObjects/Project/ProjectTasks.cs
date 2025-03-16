using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System.Linq;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Project
{
    public class ProjectTasks
    {
        public ProjectTasks(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public WebItem ProjectFrame { get; } = new WebItem(
            "//iframe[contains(@src, '/workgroups/group/')]",
            "Фрейм сладера проекта");


        /// <summary>
        /// Показать задачи в виде списка
        /// </summary>
        private void SwitchToListView()
        {
            var listViewMode = new WebItem(
                "//a[@id='tasks_view_mode_list']",
                "Задачи в виде списка");
            listViewMode.Click();
        }

        /// <summary>
        /// Проверка, что все задачи из списка совпадают с созданными
        /// </summary>
        public bool CheckTasks(List<string> tasks)
        {
            ProjectFrame.SwitchToFrame();
            SwitchToListView();
            foreach ( string task in tasks )
            {
                var taskItems = new WebItem(
                $"//a[@class='task-title task-status-text-color-in-progress' and text()='{task}']",
                "элемент списка задач");
                bool isInTasks = tasks.Contains(task);
                if (!isInTasks)
                {
                    return false;
                }
            }
            WebDriverActions.SwitchToDefaultContent();
            return true;
        }

        /// <summary>
        /// Проверка, что все ответственные за задачу пользователи добавленны ранее в поток
        /// </summary>
        public bool CheckExecutors(List<string> users)
        {
            ProjectFrame.SwitchToFrame();
            SwitchToListView();
            foreach (string user in users)
            {
                var taskItems = new WebItem(
                $"//a[@class='tasks-grid-username' and contains(@onclick, '{user}')]",
                "исполнитель задачи");
                bool isInUsers = users.Contains(user);
                if (!isInUsers)
                {
                    return false;
                }
            }
            WebDriverActions.SwitchToDefaultContent();
            return true;
        }
    }
}
