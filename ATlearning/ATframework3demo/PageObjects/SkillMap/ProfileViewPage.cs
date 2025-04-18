using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class ProfileViewPage
    {
        public IWebDriver Driver { get; }

        public ProfileViewPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
