using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    /// <summary>
    /// Класс для бургера на странице "актуальность аттестаций"
    /// </summary>
    public class CertificationRelevancePopup
    {
        public IWebDriver Driver { get; }

        public CertificationRelevancePopup(string username, IWebDriver driver = default)
        {
            Driver = driver;
            var burger = new WebItem(
                $"//span[contains(text(), '{username}')]/../../..//a",
                $"Бургер напротив элемента с именем {username}");

            burger.Click();
        }

        public CertificationResultPage CertificateEmployee()
        {
            var CertificateEmployeeBtn = new WebItem(
            $"//a[contains(@href, '/certification-result/')]",
            "Кнопка 'аттестовать сотрудника'");
            CertificateEmployeeBtn.Click();

            return new CertificationResultPage();
        }
    }
}
