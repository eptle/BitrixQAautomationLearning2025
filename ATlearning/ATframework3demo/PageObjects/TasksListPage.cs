using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Flows;
using ATframework3demo.PageObjects.Project;
using ATframework3demo.PageObjects.ProjectCreation;
using OpenQA.Selenium;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        public TasksListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Навести на кнопку "Проекты" сверху страницы и нажать на плюсик под этой кнопкой. 
        /// </summary>
        public ChooseTypeOfProject CreateProjectBtn()
        {
            var projectBtn = new WebItem(
                "//span[@class=\"main-buttons-item-text-box\" and text()='Проекты']", 
                "Кнопка 'Проекты' сверху страницы");
            projectBtn.Hover();
            var addProjectBtn = new WebItem(
                "//a[@href='/company/personal/user/1/groups/create/?firstRow=project']", 
                "Плюсик под кнопкой проекты, который появляется при наведении на кнопку Проекты");
            addProjectBtn.Click();
            return new ChooseTypeOfProject();
        }

        /// <summary>
        /// Нажать кнопку Потоки сверху страницы
        /// </summary>
        public FlowsPage OpenFlows()
        {
            var flowsBtn = new WebItem(
                "//a[@class='main-buttons-item-link' and contains(@href, '/tasks/flow/')]", 
                "кнопка Потоки в верхнем меню");
            flowsBtn.Click();
            return new FlowsPage();
        }

        /// <summary>
        /// Проверяет, существует ли ИПР по заданному профилю в списке задач
        /// </summary>
        /// <param name="profileName">название профиля</param>
        /// <returns></returns>
        public bool IsIPRtaskExists(string profileName)
        {
            var taskTitle = new WebItem(
                $"//a[@class='task-title task-status-text-color-in-progress' and text()='ИПР по профилю: {profileName}']",
                "Заголовок задачи в списке");

            if (taskTitle.Count() == 0)
                return false;

            return true;
        }
    }
}