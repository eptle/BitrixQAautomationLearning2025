using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class StatByProfilesGraphPage
    {
        public IWebDriver Driver { get; }

        public StatByProfilesGraphPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
