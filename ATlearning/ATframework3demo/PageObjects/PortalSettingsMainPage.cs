using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class PortalSettingsMainPage
    {
        public PortalSettingsMainPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public PortalSettingsMainPage DisableDefaultSendToAll()
        {
            ChangeDefaultSendToAllState(false);
            return new PortalSettingsMainPage(Driver);
        }

        public PortalSettingsMainPage EnableDefaultSendToAll()
        {
            ChangeDefaultSendToAllState(true);
            return new PortalSettingsMainPage(Driver);
        }

        public PortalSettingsMainPage ChangeDefaultSendToAllState(bool mustBeChecked)
        {
            //снять галочку
            var checkboxSendToAllByDefault = new WebItem("//input[@id='default_livefeed_toall']", "Чекбокс настройки Адресация всем по умолчанию");
            bool isChecked = checkboxSendToAllByDefault.Checked(Driver);
            if(isChecked != mustBeChecked)
                checkboxSendToAllByDefault.Click(Driver);
            return new PortalSettingsMainPage(Driver);
        }

        public PortalSettingsMainPage Save()
        {
            //ткнуть в кнопку сохранить
            var btnSave = new WebItem("//span[contains(text(), 'Сохранить настройки')]", "Кнопка Сохранить настройки");
            btnSave.Click(Driver);
            return new PortalSettingsMainPage(Driver);
        }
    }
}
