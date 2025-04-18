using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class IPRlistPage
    {
        public IWebDriver Driver { get; }

        public IPRlistPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
