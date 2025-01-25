using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework.BitrixCPinterraction;

namespace Aqua.Selenium.General
{
    public class Bitrix24Group
    {
        public static Bitrix24Group Freelance
        {
            get => new Bitrix24Group
            {
                Name = "Фриланс",
                IsExtra = true,
            };
        }

        public string Name { get; set; }
        public bool IsExtra { get; set; }

        string GetIdByName(Uri portalUri, User portalAdmin)
        {
            var result = PortalDatabaseExecutor.ExecuteQuery("SELECT ID from b_sonet_group WHERE NAME = '" + Name + "'", portalUri, portalAdmin);
            return result.Count == 0 ? null : result[0].ID;
        }

        public void AddUserToGroupByPHP(User user, Uri portalUri, User portalAdmin)
        {
            Log.Info("Добавляем пользователя " + user.LoginAkaEmail + " в группу " + Name + " скриптом");
            string groupId = CreateGroupIfNotPresent(portalUri, portalAdmin);
            string userId = user.GetDBid(portalUri, portalAdmin);
            if (string.IsNullOrEmpty(userId))
                throw new Exception($"Юзера с логином {user.LoginAkaEmail} нет на портале");
            AddUserToGroup(userId, groupId, portalUri, portalAdmin);
        }

        /// <summary>
        /// Создаёт группу на портале, если её там нет
        /// </summary>
        /// <param name="portalUri"></param>
        /// <param name="portalAdmin"></param>
        /// <returns>Id созданной группы</returns>
        public string CreateGroupIfNotPresent(Uri portalUri, User portalAdmin)
        {
            string groupId = GetIdByName(portalUri, portalAdmin);

            if (string.IsNullOrEmpty(groupId))
            {
                string php =
                    $"$arFields[\"NAME\"] = '{Name}';\r\n" +
                    $"$arFields[\"SITE_ID\"] = '{(IsExtra ? "co" : "s1")}';\r\n" +
                    $"$arFields[\"OPENED\"] = 'Y';\r\n" +
                    $"$arFields[\"VISIBLE\"] = 'Y';\r\n" +
                    $"$arFields[\"PROJECT\"] = 'N';\r\n";

                php += @"
                    global $USER;
	                CModule::IncludeModule('socialnetwork');
	                $arFields[""SUBJECT_ID""] = 1;
	                $arFields[""OWNER_ID""] = $USER->GetID();
	                $arFields[""NUMBER_OF_MEMBERS""] = 1;
	                $arFields[""NUMBER_OF_MODERATORS""] = 1;
	                $arFields[""INITIATE_PERMS""] = ""K"";
	                $arFields[""SPAM_PERMS""] = ""K"";
	                $arFields[""CLOSED""] = ""N"";

	                $id = CSocNetGroup::CreateGroup($arFields[""OWNER_ID""], $arFields, true);
	                CSocNetFeatures::SetFeature(
		                SONET_ENTITY_GROUP,
		                $id,
		                'files',
		                true,
		                false
	                );
                    if($id > 0){
	                    echo ""<br/> - Добавлена группа: <b>"" . $arFields['NAME'] . ""</b>"";
                    }";
                var phpExecutor = new PHPcommandLineExecutor(portalUri, portalAdmin.LoginAkaEmail, portalAdmin.Password);
                string phpResult = phpExecutor.Execute(php);
                if(phpResult?.Contains("Добавлена группа") != true)
                    throw new Exception($"Группа {Name} не создалась:\r\n{phpResult}");
                groupId = GetIdByName(portalUri, portalAdmin);
            }

            return groupId;
        }

        static void AddUserToGroup(string userId, string groupId, Uri portalUri, User portalAdmin)
        {
            string php =
                $"$arFields[\"USER_ID\"] = '{userId}';\r\n" +
                $"$arFields[\"GROUP_ID\"] = '{groupId}';\r\n" +
                $"$arFields[\"ROLE\"] = 'K';\r\n" +
                "$arFields[\"=DATE_CREATE\"] = $GLOBALS[\"DB\"]->CurrentTimeFunction();\r\n" +
                "$arFields[\"=DATE_UPDATE\"] = $GLOBALS[\"DB\"]->CurrentTimeFunction();\r\n" +
                $"$arFields[\"INITIATED_BY_TYPE\"] = 'G';\r\n" +
                "$arFields[\"INITIATED_BY_USER_ID\"] = $USER->GetID();\r\n" +
                $"$arFields[\"MESSAGE\"] = false;\r\n";

            php += @"
                CModule::IncludeModule(""socialnetwork"");
                $ID = CSocNetUserToGroup::Add($arFields);

		        if ($ID == true) {
			        echo ""Пользователь с ID = "";
			        echo $arFields[""USER_ID""];
			        echo "" успешно добавлен в группу с ID = "";
			        echo $arFields[""GROUP_ID""];
		        } else {
			        echo ""Добавление пользователя в группу не сработало"";
		        }";

            var phpExecutor = new PHPcommandLineExecutor(portalUri, portalAdmin.LoginAkaEmail, portalAdmin.Password);
            string phpResult = phpExecutor.Execute(php);

            if (phpResult?.Contains("успешно добавлен в группу") == true)
                Log.Info("Пользователь " + userId + " успешно добавлен в группу " + groupId);
            else
                throw new Exception($"Пользователь с ID='{userId}' не добавился в группу с ID='{groupId}':\r\n{phpResult}");
        }
    }
}
