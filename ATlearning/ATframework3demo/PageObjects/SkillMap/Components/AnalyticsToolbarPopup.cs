using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components
{
    public class AnalyticsToolbarPopup
    {
        public IWebDriver Driver { get; }

        public AnalyticsToolbarPopup(IWebDriver driver = default)
        {
            Driver = driver;

            var AnalyticsBtn = new WebItem(
            "//button[contains(@class, 'analytics-button')]",
            "Кнопка 'Аналитика и отчёты'");

            AnalyticsBtn.Click();
        }

        public AllAttestationsPage AllAttestations()
        {
            var OpenProfileBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[1]",
            "Кнопка 'все атестации'");
            OpenProfileBtn.Click();

            return new AllAttestationsPage();
        }

        public IPRlistPage IPRlist()
        {
            var EditProfileBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[2]",
            "Кнопка 'список всех ипр'");
            EditProfileBtn.Click();

            return new IPRlistPage();
        }

        public CertificationRelevancePage CertificationRelevance()
        {
            var CertificateEmployeeBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[3]",
            "Кнопка 'актуальность аттестаций'");
            CertificateEmployeeBtn.Click();

            return new CertificationRelevancePage();
        }

        public StatByProfilesGridPage StatByProfilesGrid()
        {
            var SeeCertificationsBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[4]",
            "Кнопка 'статистика по профилям (грид)'");
            SeeCertificationsBtn.Click();

            return new StatByProfilesGridPage();
        }

        public StatByProfilesGraphPage StatByProfilesGraph()
        {
            var SeeCertificationsBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[5]",
            "Кнопка 'статистика по профилям (график)'");
            SeeCertificationsBtn.Click();

            return new StatByProfilesGraphPage();
        }
    }
}
