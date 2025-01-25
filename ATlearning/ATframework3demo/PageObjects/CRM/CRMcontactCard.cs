
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CRM
{
    public class CRMcontactCard
    {
        public CRMcontactsPage Close()
        {
            throw new NotImplementedException();
            return new CRMcontactsPage;
        }

        internal bool AssertNameField(Bitrix24CRMcontacts name)
        {
            throw new NotImplementedException();
            return new WebItem("//path", "Заголовок слайдера контакта")
                .AssertTextContains(name.Name, $"Имя контакта некорректное. Ожидалось: {name.Name}");
        }
    }
}
