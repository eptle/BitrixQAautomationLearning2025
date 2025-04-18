using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class SkillmapMainPage
    {
        public IWebDriver Driver { get; }

        public SkillmapMainPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
