using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.NewsFeed;
using ATframework3demo.PageObjects.SkillMap;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        public IWebDriver Driver { get; }

        public PortalHomePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public PortalLeftMenu LeftMenu => new PortalLeftMenu(Driver);

        public NewsPage NewsFeed => new NewsPage(Driver);


        /// <summary>
        /// Переход во вкладку SkillMap по Uri
        /// </summary>
        /// <returns></returns>
        public SkillmapMainPage GoToSkillmap()
        {
            string SkillmapUri = "http://bitrix.dev.bx/skillmap/";
            WebDriverActions.OpenUri(new Uri(SkillmapUri));
            return new SkillmapMainPage();
        }
    }
}
