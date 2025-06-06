﻿using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.IPR
{
    public class IPRlistPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public IPRlistPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public PortalLeftMenu LeftMenu => new PortalLeftMenu(Driver);

        /// <summary>
        /// Проверяет статус начатого ИПР
        /// </summary>
        public bool IsIPRstat(string profileName)
        {
            var taskTitle = new WebItem(
                $"//tr[contains(@class, 'main-grid-row')]" +
               $"[.//span[contains(text(), '{profileName}')] " +
               "and .//span[text()='Выполняется']]",
                "Статус ИПР");

            return taskTitle.Count() > 0;
        }

        /// <summary>
        /// Проверяет, сущестует ли ИПР в спсике всех ИПР
        /// </summary>
        public bool IsIPRlistExists(string profileName)
        {
            var taskTitle = new WebItem(
                $"//tr[contains(@class, 'main-grid-row')]" +
                $"[.//span[contains(text(), '{profileName}')]]",
                $"ИПР по профилю '{profileName}'");

            return taskTitle.Count() > 0;
        }
    }
}
