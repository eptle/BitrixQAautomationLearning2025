using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Company;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.IPR
{
    public class IPRstatPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public IPRstatPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem ChooseEmployeeBtn { get; } = new WebItem(
            "//select[@name='employee_id']",
            "Выпадающий список выбора сотруднкиа для создания ИПР");
        /*public WebItem EmployeeBtn { get; } = new WebItem(
            "//option[contains(text(), {employeeName})]",
            "Выпадающий список выбора сотруднкиа для создания ИПР");*/

        public IPRlistPage CreateIPR(string employeeName)
        {
            ChooseEmployeeBtn.Click();
            //EmployeeBtn.Click();
            return new IPRlistPage();
        }
    }
}
