using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class AllAttestationsPage
    {
        public IWebDriver Driver { get; }

        public AllAttestationsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
