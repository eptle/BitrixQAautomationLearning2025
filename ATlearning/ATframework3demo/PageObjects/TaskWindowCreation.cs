using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Flows;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects
{
    public class TaskWindowCreation
    {
        public TaskWindowCreation(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public WebItem TaskFrame { get; } = new WebItem(
            "//iframe[contains(@src, 'company/personal/user')]",
            "Фрейм сладера создания задачи");

        /// <summary>
        /// Добавить заголовок задачи
        /// </summary>
        public TaskWindowCreation AddTitle(string task)
        {
            TaskFrame.SwitchToFrame();
            var input = new WebItem(
                "//input[contains(@name, '[TITLE]')]",
                "Поле ввода заголовка");
            input.SendKeys(task);
            WebDriverActions.SwitchToDefaultContent();
            return new TaskWindowCreation();
        }

        /// <summary> 
        /// Нажать сочетание Ctrl+Enter для создания задачи 
        /// </summary> 
        public FlowsPage CreateTask()
        {
            TaskFrame.SwitchToFrame();
            var createBtn = new WebItem(
                "//input[contains(@name, '[TITLE]')]",
                "Поставить задачу");
            createBtn.SendKeys(Keys.Control + Keys.Enter);
            WebDriverActions.SwitchToDefaultContent();
            return new FlowsPage();
        }
    }
}
