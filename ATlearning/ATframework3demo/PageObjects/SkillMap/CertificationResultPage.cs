using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CertificationResultPage
    {
        public IWebDriver Driver { get; }

        public CertificationResultPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
