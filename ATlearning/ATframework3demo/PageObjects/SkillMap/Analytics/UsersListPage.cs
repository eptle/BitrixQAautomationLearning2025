using ATframework3demo.PageObjects.SkillMap.Components;
using ATframework3demo.PageObjects.SkillMap.Components.PopUps;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class UsersListPage : BaseGridPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public UsersListPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public UsersListPopup ClickOnBurger(string username) => new UsersListPopup(username, Driver);
    }
}
