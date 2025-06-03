using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    /// <summary>
    /// Класс для попапа на главной странице напротив каждого профиля
    /// </summary>
    public class SkillmapMainPopup
    {
        private string ID;

        public IWebDriver Driver { get; }

        public SkillmapMainPopup(string profileName, IWebDriver driver = default)
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

        public ProfileViewPage OpenProfile()
        {
            var OpenProfileBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[1]",
            "Кнопка 'открыть'");
            OpenProfileBtn.Click();

            return new ProfileViewPage();
        }

        public EditProfilePage EditProfile()
        {
            var EditProfileBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[2]",
            "Кнопка 'редактировать'");
            EditProfileBtn.Click();

            return new EditProfilePage();
        }

        public CertificationResultPage CertificateEmployee()
        {
            var CertificateEmployeeBtn = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[3]",
            "Кнопка 'аттестовать сотрудника'");
            CertificateEmployeeBtn.Click();

            return new CertificationResultPage();
        }

        public PlanCertificationPopup PlanCertification()
        {
            var SeeCertificationsBtn = new WebItem(
            $"//div[@class='menu-popup-items']/span[@onclick='openCertificationPopup()']",
            "Кнопка 'посмотреть статистику'");
            SeeCertificationsBtn.Click();

            return new PlanCertificationPopup();
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
