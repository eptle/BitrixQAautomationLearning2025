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

        public WebItem ChooseSpecialistBtn { get; } = new WebItem(
            "//select[@name='specialist_id']",
            "Выпадающий список выбора профиля специалиста для создания ИПР");

        public WebItem DescriptionSpecialistBtn { get; } = new WebItem(
            "//textarea[@id='description']",
            "Описание ИПР");

        public WebItem DeadlineOfIPRBtn { get; } = new WebItem(
            "//input[@type='datetime-local']",
            "Дедлайн ИПР");

        public WebItem CreateIPRBtn { get; } = new WebItem(
            "//button[@name='create_ipr']",
            "Зеленая кнопка 'Cоздать'");

        public WebItem GetProfileBtn(string profileName)
        {
            return new WebItem(
            $"//option[contains(text(), '{profileName}')]",
                "Клик на профиль специалиста");
        }

        public WebItem GetEmployeeBtn(string employeeName)
        {
            return new WebItem(
                $"//option[contains(text(), '{employeeName}')]",
                "Клик на сотрудника");
        }

        public WebItem Deadline { get; } = new WebItem(
            "//input[@id='deadline']",
            "Дедлайн ипр");

        public IPRlistPage CreateIPR(string employeeName, string profileName)
        {
            ChooseEmployeeBtn.Click();
            GetEmployeeBtn(employeeName).Click();
            GetProfileBtn(profileName).Click();
            DescriptionSpecialistBtn.SendKeys("description of IPR");
            Deadline.SetArributeValue("value", "2025-12-31T23:59");
            CreateIPRBtn.Click();
            return new IPRlistPage();
        }
    }
}
