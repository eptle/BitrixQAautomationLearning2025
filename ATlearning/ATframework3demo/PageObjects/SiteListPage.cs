using OpenQA.Selenium;

namespace atFrameWork2.PageObjects
{
    public class SiteListPage
    {
        public SiteListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
    }
}