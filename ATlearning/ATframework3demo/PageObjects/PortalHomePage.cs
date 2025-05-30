﻿using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Company;
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
            string SkillmapUri = TestCase.RunningTestCase.TestPortal.PortalUri.ToString() + "skillmap/";
            WebDriverActions.OpenUri(new Uri(SkillmapUri));
            return new SkillmapMainPage();
        }
        public EmployeeListPage GoToEmployee()
        {
            string EmployeeListUri = "http://bitrix.dev.bx/company/";
            WebDriverActions.OpenUri(new Uri(EmployeeListUri));
            return new EmployeeListPage();
        }
    }
}
