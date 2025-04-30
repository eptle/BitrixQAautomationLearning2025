using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    /// <summary>
    /// Класс для попапа при клике на "отчеты" на тулбаре
    /// </summary>
    public class AnalyticsToolbarPopup
    {
        public IWebDriver Driver { get; }

        public AnalyticsToolbarPopup(IWebDriver driver = default)
        {
            Driver = driver;

            var AnalyticsBtn = new WebItem(
                "//button[contains(@class, 'analytics-button')]",
                "Кнопка 'отчёты'");

            AnalyticsBtn.Click();
        }

        public AllAttestationsPage AllAttestations()
        {
            var OpenProfileBtn = new WebItem(
                "//a[contains(@href, 'all-certification')]",
                "Кнопка 'все атестации'");

            OpenProfileBtn.Click();

            return new AllAttestationsPage();
        }

        public CertificationRelevancePage CertificationRelevance()
        {
            var CertificateEmployeeBtn = new WebItem(
                "//a[contains(@href, 'certification-relevance')]",
                "Кнопка 'актуальность аттестаций'");

            CertificateEmployeeBtn.Click();

            return new CertificationRelevancePage();
        }

        public StatByProfilesPage StatByProfiles()
        {
            var SeeCertificationsBtn = new WebItem(
                "//a[contains(@href, 'overall-grade')]",
                "Кнопка 'статистика по профилям (грид)'");

            SeeCertificationsBtn.Click();

            return new StatByProfilesPage();
        }

        public UsersListPage UsersList()
        {
            var SeeCertificationsBtn = new WebItem(
                "//div[@class='menu-popup-items']//a[contains(@href, 'users-list')]",
                "Кнопка 'статистика по профилям (грид)'");

            SeeCertificationsBtn.Click();

            return new UsersListPage();
        }
    }
}
