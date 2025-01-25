using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalLeftMenu
    {
        public IWebDriver Driver { get; }

        public PortalLeftMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        private void ClickMenuItem(WebItem menuItem)
        {
            var menuItemsArea = new WebItem("//div[@id='menu-items-block']", "Область с пунктами левого меню");
            if (menuItemsArea.Size(Driver).Width < 150)
            {
                var expandMenuButton = new WebItem("//div[@class='menu-switcher']", "Кнопка сворачивания левого меню");
                expandMenuButton.Hover(Driver);
                var menuHeader = new WebItem("//div[@class='menu-items-header-title']", "Кнопка сворачивания левого меню");
                menuHeader.Click(Driver);
            }

            if (menuItem.WaitElementDisplayed(driver: Driver) == false)
            {
                var teamWorkGroupEtc = new WebItem("//li[@data-type='system_group' and not(@id='bx_left_menu_menu_marketplace_group')]", 
                    "Кнопка группы пунктов меню главного инструмента");
                if(teamWorkGroupEtc.WaitElementDisplayed(2, driver: Driver) && teamWorkGroupEtc.GetAttribute("data-collapse-mode") == "collapsed")
                    teamWorkGroupEtc.Click(Driver);

                if (menuItem.WaitElementDisplayed(driver: Driver) == false)
                {
                    //развернуть меню Ещё
                    var btnMore = new WebItem("//span[@id='menu-more-btn-text']", "Кнопка Ещё левого меню");
                    btnMore.Click(Driver);
                }
            }
            //клик в пункт меню
            menuItem.Click(Driver);
        }

        public TasksListPage OpenTasks()
        {
            ClickMenuItem(new WebItem("//li[@id='bx_left_menu_menu_tasks']", "Пункт левого меню 'Задачи'"));
            return new TasksListPage(Driver);
        }

        public SiteListPage OpenSites()
        {
            ClickMenuItem(new WebItem("//li[@id='bx_left_menu_menu_sites']", "Пункт левого меню 'Сайты'"));
            return new SiteListPage(Driver);
        }

        public PortalSettingsMainPage OpenSettings()
        {
            var btnSettings = new WebItem("//li[@id='bx_left_menu_menu_configs_sect']", "Пункт левого меню настройки");
            ClickMenuItem(btnSettings);
            return new PortalSettingsMainPage(Driver);
        }

        public NewsPage OpenNews()
        {
            //клик в пункт меню Новости
            var btnNews = new WebItem("//li[@id='bx_left_menu_menu_live_feed']", "Пункт левого меню Новости");
            ClickMenuItem(btnNews);
            return new NewsPage(Driver);
        }
    }
}
