using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CircularDiagramPage
    {
        public IWebDriver Driver { get; }

        public CircularDiagramPage(IWebDriver driver = default)
        {
            Driver = driver;
        }
    }
}
