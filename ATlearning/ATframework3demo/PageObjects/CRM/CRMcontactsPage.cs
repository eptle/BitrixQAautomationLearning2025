using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CRM
{
    public class CRMcontactsPage
    {
        public CRMcontactEditForm OpenCreationForm()
        {
            throw new NotImplementedException();
            return new CRMcontactEditForm();
        }

        public CRMcontactCard OpenContact(Bitrix24CRMcontacts contact)
        {
            throw new NotImplementedException();
            return new CRMcontactCard();
        }
    }
}
