using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.CRM;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_CRM : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases() // этот метод добавляет наш тест-кейс в очередь/список
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание сделки", homePage => CreateDeal(homePage)));
            return caseCollection;
        }

        void CreateDeal(PortalHomePage homePage) // тело самого кейса. 1 метод -- 1 тест кейс
        {
            // подготовка среды
            // допустим, нам надо создать новый контакт
            var phpExecutor = new PHPcommandLineExecutor(TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            var dmitrix = new Bitrix24CRMcontacts { Name = "Dmitrix" + HelperMethods.GetDateTimeSaltString() };

            //перейти в црм
            var contactCard = homePage
                .LeftMenu
                .OpenCRM()
            //открыть контакты
                .OpenContacts()
            //открыть создание контакта 
                .OpenCreationForm()
            //заполнить поля
                .SetName(dmitrix)
            //сохранить
                .Save()
            //закрыть просмотр контакта
                .Close()
            //проверить создание контакта
                .OpenContact(dmitrix);
            //открыть проверить поля
            contactCard.AssertNameField(dmitrix);
            contactCard.Close();
            //обновить страницу
            WebDriverActions.Refresh();
            //проверить создание контакта
            //открыть контакт и проверить поля
            new CRMcontactsPage()
                .OpenContact(dmitrix);
        }
    }
}
