using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class SkillmapMainPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public SkillmapMainPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }
    }
}
