using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Company
{
    public class InviteEmployees
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public InviteEmployees(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem EnterMailBtn { get; } = new WebItem(
            "//input[@placeholder='Введите e-mail'][1]",
            "Поле для ввода email");
        public WebItem EnterNameBtn { get; } = new WebItem(
            "//input[@placeholder='Имя'][1]",
            "Поле для ввода имени");
        public WebItem EnterSernameBtn { get; } = new WebItem(
            "//input[@placeholder='Фамилия'][1]",
            "Поле для ввода фамилии");
        public WebItem SaveEmployeeBtn { get; } = new WebItem(
            "//button[@id='intranet-invitation-btn']",
            "Кнопка 'Пригласить'");

        public EmployeeListPage AddEmployee(string employeeName)
        {
            //переключаемся во фрейм
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            //вводим почту
            string email = employeeName + "@mail.ru";
            EnterMailBtn.Click();
            EnterMailBtn.SendKeys(email);
            //вводим имя
            string name = "name" + employeeName;
            EnterNameBtn.Click();
            EnterNameBtn.SendKeys(name);
            //вводим фамилию
            string sername = "sername" + employeeName;
            EnterSernameBtn.Click();
            EnterSernameBtn.SendKeys(sername);
            SaveEmployeeBtn.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new EmployeeListPage();
        }
    }
}
