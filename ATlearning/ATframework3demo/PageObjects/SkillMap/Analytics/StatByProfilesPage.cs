using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class StatByProfilesPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public StatByProfilesPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }
    }
}
