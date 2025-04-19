using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class CertificationRelevance
    {
        public IWebDriver Driver { get; }

        public CertificationRelevance(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
