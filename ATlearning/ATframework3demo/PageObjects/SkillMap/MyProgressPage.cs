using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class MyProgressPage
    {
        public IWebDriver Driver { get; }

        public MyProgressPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
