using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using ATframework3demo.PageObjects.SkillMap.Components.PopUps;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class CertificationRelevancePage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public CertificationRelevancePage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public object ActionToEmployee(string employeeName, int listItemNumber)
        {
            var burger = new WebItem(
                $"//span[contains(text(), '{employeeName}')]/../../..//a",
                $"Бургер напротив сотрудника с именем {employeeName}");

            burger.Click();
            throw new NoSuchElementException();
        }

        /// <summary>
        /// Кликаем по бургеру напротив выбранного пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns></returns>
        public CertificationRelevancePopup ClickOnBurger(string username) => new CertificationRelevancePopup(username, Driver);
    }
}
