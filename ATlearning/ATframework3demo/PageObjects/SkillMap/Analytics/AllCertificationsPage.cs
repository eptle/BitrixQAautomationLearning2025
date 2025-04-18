using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class AllCertificationsPage
    {
        public IWebDriver Driver { get; }

        public AllCertificationsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
