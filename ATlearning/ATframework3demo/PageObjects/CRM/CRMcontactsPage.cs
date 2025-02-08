using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CRM
{
    public class CRMcontactsPage
    {
        WebItem ContactSliderFrame => new WebItem("//div[@id='crm_contact_slider']", "Фрейм с контактом");

        WebItem ContactNameLink(string contactName) => new WebItem($"a[text()='{ contactName }']", "Ссылка на контакт в гриде");

        public CRMcontactEditForm OpenCreationForm()
        {
            throw new NotImplementedException();
            return new CRMcontactEditForm();
        }

        public CRMcontactCard OpenContact(Bitrix24CRMcontacts contact)
        {
            ContactNameLink(contact.Name).Click();
            ContactSliderFrame.SwitchToFrame();
            throw new NotImplementedException();
            return new CRMcontactCard();
        }
    }
}
