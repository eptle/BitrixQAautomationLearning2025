using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    public class StatByProfilesPopup
    {
        private string ID;

        public IWebDriver Driver { get; }

        public StatByProfilesPopup(string profileName, IWebDriver driver = default)
        {
            Driver = driver;
            var burger = new WebItem(
                $"//span[contains(text(), '{profileName}')]/../../..//a",
                $"Бургер напротив элемента с именем {profileName}");

            burger.Click();

            var getID = new WebItem(
                $"//span[contains(text(), '{profileName}')]/../../../td[2]//span",
                $"ID профиля {profileName}");

            ID = getID.InnerText();
        }

        public CertificationListPage SeeCertifications()
        {
            var SeeCertificationsBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[4]",
            "Кнопка 'посмотреть аттестации'");
            SeeCertificationsBtn.Click();

            return new CertificationListPage();
        }

        public CircularDiagramPage SeeStatistics()
        {
            var SeeCertificationsBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[5]",
            "Кнопка 'посмотреть статистику'");
            SeeCertificationsBtn.Click();

            return new CircularDiagramPage();
        }
    }
}
