using atFrameWork2.SeleniumFramework;
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
    }
}