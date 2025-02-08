
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.CRM
{
    public class CRMcontactCard
    {
        public CRMcontactsPage Close()
        {
            WebDriverActions.SwitchToDefaultContent();
            return new CRMcontactsPage();
        }

        public bool AssertNameField(Bitrix24CRMcontacts name)
        {
            throw new NotImplementedException();
            return new WebItem("//path", "Заголовок слайдера контакта")
                .AssertTextContains(name.Name, $"Имя контакта некорректное. Ожидалось: {name.Name}");
        }

        public CRMcontactCard ChangeResponsible(User newResponsible)
        {
            var sliderHeader = new WebItem("//path", "Заголовок слайда контакта");
            bool displayed = sliderHeader.WaitElementDisplayed(50);


            bool wResult = Waiters.WaitForCondition(() =>
            {
                return displayed;
            }, 5, 50, $"Ждем появления {sliderHeader.Description}");

            if(!wResult)
            {
                Log.Error($"Не дождались появления {sliderHeader.Description}");
                throw new Exception($"Не дождались появления {sliderHeader.Description}");
            }

            return this;
        }

        public void AssertResponsible(User newResponsible)
        {
            throw new NotImplementedException();
        }
    }
}
