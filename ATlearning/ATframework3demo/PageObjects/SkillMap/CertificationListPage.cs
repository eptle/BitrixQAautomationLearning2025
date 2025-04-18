using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CertificationListPage
    {
        public IWebDriver Driver { get; }

        public CertificationListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
