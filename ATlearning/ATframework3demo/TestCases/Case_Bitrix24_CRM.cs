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
            // caseCollection.Add(new TestCase("Смена ответственного", homePage => ChangeContactResponsible(homePage)));
            return caseCollection;
        }

        void ChangeContactResponsible(PortalHomePage homePage) // тело самого кейса. 1 метод -- 1 тест кейс
        {
            //a[text()='123123123'] -- посмортеть текст внутри тега

            // создать контакт через пхп
            var contactToChangeResponsible = new Bitrix24CRMcontacts { Name = "Dmitrix" + HelperMethods.GetDateTimeSaltString() };
            contactToChangeResponsible.CreateByAPI(TestCase.RunningTestCase.TestPortal);
            // создать сотрудника для передачи прав
            var newResponsible = TestCase.RunningTestCase.CreatePortalTestUser(false);

            //перейти в црм
            var CRMbasePage = homePage
                .LeftMenu
                .OpenCRM();

            //открыть контакты
            CRMbasePage
                .OpenContacts()
            //открыть контакт
                .OpenContact(contactToChangeResponsible)
            //сменить ответственного
                .ChangeResponsible(newResponsible)
                .Close();

            // дать права новому юзеру на црм
            /*CRMbasePage
                .OpenRightsSettings()
                .AddDirector(newResponsible)
                .Save();
            */
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
            new PortalLoginPage(TestCase.RunningTestCase.TestPortal)
                .Login(newResponsible)
                .LeftMenu
                .OpenCRM()
                .OpenContacts()
                .OpenContact(contactToChangeResponsible)
                .AssertResponsible(newResponsible);
        }
    }
}
