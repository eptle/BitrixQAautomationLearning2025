using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.CRM
{
    public class CRMbasePage
    {
        WebItem ClientsButton =>
            new WebItem(
                "//div[@id='crm_control_panel_menu_crm_clients']/span",
                "Кнопка Контакты в верхнем меню"
                );

        WebItem ContactsMenuItem =>
            new WebItem(
                "//a[@href='/crm/contact/list/']",
                "Кнопка Клиенты в меню ClientsButton"
                );

        public CRMcontactsPage OpenContacts()
        {
            ClientsButton.Hover();
            ContactsMenuItem.Click();
            return new CRMcontactsPage();
        }

        public CRMcontactsPage OpenRightsSettings()
        {
            throw new NotImplementedException();
            return new CRMcontactsPage();
        }
    }
}
