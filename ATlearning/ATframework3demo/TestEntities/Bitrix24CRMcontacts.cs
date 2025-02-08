using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestEntities
{
    public class Bitrix24CRMcontacts
    {
        public string Name { get; set; }

        // создание контакста через апи. Используем после того, как создали объект класса с полем Name
        public void CreateByAPI(PortalInfo testPortal)
        {
            var phpExecutor = new PHPcommandLineExecutor(
                testPortal.PortalUri,
                testPortal.PortalAdmin.LoginAkaEmail,
                testPortal.PortalAdmin.Password
                );
            string command = $"\\Bitrix\\Main\\Loader::includeModule('crm');" +
                $"$contactFields = ['NAME' => '{ Name }'];" +
                $"$contactEntity = new \\CCrmContact();" +
                $"$contactId = $contactEntity->Add($contactFields);";
            phpExecutor.Execute(command);
        }
    }
}
