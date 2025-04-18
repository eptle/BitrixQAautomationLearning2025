using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Elements
{
    public class TopToolbar
    {
        public IWebDriver Driver { get; }

        public TopToolbar(IWebDriver driver = default)
        {
            Driver = driver;
        }

    }
}
