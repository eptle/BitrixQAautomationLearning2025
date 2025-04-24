using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class MyProgressPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public MyProgressPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }
    }
}
