using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class UsersWithoutCertificationPage
    {
        public IWebDriver Driver { get; }

        public UsersWithoutCertificationPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
