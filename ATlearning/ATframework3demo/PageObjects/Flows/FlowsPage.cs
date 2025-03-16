using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.FlowCreation;
using ATframework3demo.PageObjects.Project;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Flows
{
    public class FlowsPage
    {
        public FlowsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Нажать кнопку "Создать Поток" сверху страницы
        /// </summary>
        public AboutFlow CreateFlowBtn()
        {
            var createFlowBtn = new WebItem(
                "//button[@id='tasks-flow-add-button']",
                "Кнопка создать поток");
            createFlowBtn.Click();
            return new AboutFlow();
        }

        /// <summary>
        /// Нажать кнопку "Создать Задачу" напротив потока с заданным названием
        /// </summary>
        public TaskWindowCreation CreateTaskBtn(string flowName)
        {
            var createFlowTaskBtn = new WebItem(
                $"//a[contains(text(), '{flowName}')]//..//..//..//..//..//..//div[@class='tasks-flow__list-cell_line --start-line ']",
                "Кнопка создать задачу напротив нужного потока");
            createFlowTaskBtn.Click();
            return new TaskWindowCreation();
        }

        /// <summary>
        /// Нажать на ссылку потока под назданием потока
        /// </summary>
        public ProjectTasks OpenProject(string projectName)
        {
            var openProjectBtn = new WebItem(
                $"//div[@class='tasks-flow__list-name_info --link']//a[contains(text(), '{projectName}')]",
                "Кнопка открытия проекта под названием проекта");
            openProjectBtn.Click();
            return new ProjectTasks();
        }
    }
}
