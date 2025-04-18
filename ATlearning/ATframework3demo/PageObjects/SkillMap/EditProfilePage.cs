using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class EditProfilePage
    {
        public IWebDriver Driver { get; }

        public EditProfilePage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
