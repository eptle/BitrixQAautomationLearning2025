using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CreateSpecialistPage
    {
        public IWebDriver Driver { get; }

        public CreateSpecialistPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
