using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class StatByProfilesGridPage
    {
        public IWebDriver Driver { get; }

        public StatByProfilesGridPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
