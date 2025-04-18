using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CreateIPRpage
    {
        public IWebDriver Driver { get; }

        public CreateIPRpage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
