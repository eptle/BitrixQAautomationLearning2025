using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.IPR
{
    public class IPRlistPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public IPRlistPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }
    }
}
