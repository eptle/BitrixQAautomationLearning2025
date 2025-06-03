using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Company
{
    public class EmployeeListPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public EmployeeListPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem InviteBtn { get; } = new WebItem(
            "//div[@class='ui-toolbar-after-title-buttons']",
            "Кнопка 'Пригласить'");

        public InviteEmployees InviteEmployee()
        {
            InviteBtn.Click();
            return new InviteEmployees();
        }
    }
}
