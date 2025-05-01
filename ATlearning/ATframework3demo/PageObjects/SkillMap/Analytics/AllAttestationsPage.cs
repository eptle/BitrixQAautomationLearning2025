using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Analytics
{
    public class AllAttestationsPage : BaseGridPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public AllAttestationsPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }
    }
}
