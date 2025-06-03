using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    public class UsersListPopup
    {
        public IWebDriver Driver { get; }

        public UsersListPopup(string username, IWebDriver driver = default)
        {
            Driver = driver;
            var burger = new WebItem(
                $"//span[contains(text(), '{username}')]/../../..//a",
                $"Бургер напротив элемента с именем {username}");

            burger.Click();
        }

        public MyProgressPage UserProgress()
        {
            var CertificateEmployeeBtn = new WebItem(
            $"//div[@class='menu-popup-items']//a[contains(@href, '/progress/')]",
            "Кнопка 'аттестовать сотрудника'");
            CertificateEmployeeBtn.Click();

            return new MyProgressPage();
        }
    }
}