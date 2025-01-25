using Aqua.General;
using Aqua.Selenium.General;
using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.TestEntities;
using System.Net;
using System.Xml.Linq;

namespace ATframework3demo.BaseFramework.BitrixCPinterraction
{
    /// <summary>
    /// Скриптовые операции с юзерами портала для подготовки тестовой среды
    /// </summary>
    public class EmployeeTools
    {
        public static void AddNewIntranetUser(User userToAdd, User portalAdmin, Uri portalUrl, int departmentId = 1)
        {
            AddNewUserByPHP(userToAdd, portalAdmin, portalUrl, departmentId);
        }

        public static void AddNewExtranetUser(User userToAdd, User portalAdmin, Uri portalUrl)
        {
            AddNewUserByPHP(userToAdd, portalAdmin, portalUrl, 0);
        }

        static void AddNewUserByPHP(
            User user,
            User portalAdmin,
            Uri portalUri,
            int depID)
        {
            bool isExtra = depID == 0;
            Log.Info($"Добавление пользователя {user.NameLastName} на портал скриптом");

            string addPhp = @"
		    if ($arFields[""DEPARTMENT_ID""] == 0)
			    unset($arFields[""DEPARTMENT_ID""]);
		    else
			    $arFields[""DEPARTMENT_ID""] = [$arFields[""DEPARTMENT_ID""]];
		    $SITE_ID = ""s1"";
		    $strError = """";
		    $userID = 0;
		    $userLogin = $arFields[""ADD_EMAIL""];
		    $userID = CIntranetInviteDialog::AddNewUser($SITE_ID, $arFields, $strError);
		
		    if ($userID > 0) {
			    echo ""Пользователь "";
			    echo $userLogin;
			    echo "" успешно добавлен на портал с ID "";
			    if(is_array($userID))
				    echo $userID[0];
			    else
				    echo $userID;
			    echo ""<br/>"";
		    }

		    if ($strError != """") 
		    {
			    if(is_array($strError))
				    print_r($strError);
			    else
				    echo $strError;
		    }";

            addPhp =
                $"$arFields[\"ADD_NAME\"] = '{user.Name}';\r\n" +
                $"$arFields[\"ADD_LAST_NAME\"] = '{user.LastName}';\r\n" +
                $"$arFields[\"ADD_EMAIL\"] = '{user.LoginAkaEmail}';\r\n" +
                $"$arFields[\"DEPARTMENT_ID\"] = '{depID}';\r\n" + addPhp;

            var phpExecutor = new PHPcommandLineExecutor(portalUri, portalAdmin.LoginAkaEmail, portalAdmin.Password);
            string execResult = phpExecutor.Execute(addPhp);
            if (execResult?.Contains("Пользователь " + user.LoginAkaEmail + " успешно добавлен на портал с ID") != true)
                throw new Exception($"В ходе добавления {user.LoginAkaEmail} на портал что-то пошло не так :( \r\n: {execResult}");
            SetUserPassword(user, portalUri, portalAdmin);
            ConfirmEmail(user, portalUri, portalAdmin);
            //Добавляем экстранетчика в группу Фриланс
            if (isExtra)
                Bitrix24Group.Freelance.AddUserToGroupByPHP(user, portalUri, portalAdmin);
            else
            {
                //в оригинальном фреймворке этого кода нет, либо был где то потерян при переносе, но без него магии не будет
                var result = PortalDatabaseExecutor.ExecuteQuery("SELECT ID from b_group WHERE STRING_ID = 'EMPLOYEES_s1'", portalUri, portalAdmin);
                string employeesGroupId = result.Count == 0 ? null : result[0].ID;
                if (string.IsNullOrEmpty(employeesGroupId))
                    throw new WebException("Не удалось получить ID группы 'Сотрудники'");
                phpExecutor.Execute($"CUser::AppendUserGroup({user.GetDBid(portalUri, portalAdmin)}, {employeesGroupId})");
            }

            Log.Info($"Пользователь {user.NameLastName} успешно добавлен на портал");
        }

        static void SetUserPassword(
            User user,
            Uri portalUri,
            User adminUser)
        {
            string userId = user.GetDBid(portalUri, adminUser);
            string userGroupIds = GetUserGroupIds(userId, portalUri, adminUser);
            string pwdToSet = user.Password;
            if (string.IsNullOrEmpty(userId))
                throw new Exception($"Юзера с логином {user.LoginAkaEmail} нет на портале");

            string php =
                $"$arFields[\"PASSWORD\"] = '{pwdToSet}';\r\n" +
                $"$groupIDS = '{userGroupIds}';\r\n" +
                $"$userID = '{userId}';\r\n";

            php += @"
                $objUser = new CUser;
		        $arGroupsIDs = explode("","", $groupIDS);
		        $rsUser = CUser::GetByID($userID);
		        $arUser = $rsUser->Fetch();

		        foreach ($arFields as $key => $value) 
		        {
			        if($key != ""PASSWORD"")
				        $arUser[$key] = $value;
		        }

		        $fields = array(
			        ""NAME"" => $arUser[""NAME""],
			        ""LAST_NAME"" => $arUser[""LAST_NAME""],
			        ""EMAIL"" => $arUser[""EMAIL""],
			        ""LOGIN"" => $arUser[""LOGIN""],
			        ""LID"" => $arUser[""LID""],
			        ""ACTIVE"" => $arUser[""ACTIVE""],
			        ""GROUP_ID"" => $arGroupsIDs,
		        );

		        if($arFields[""PASSWORD""] != null)
		        {
			        $fields[""PASSWORD""] = $arFields[""PASSWORD""];
			        $fields[""CONFIRM_PASSWORD""] = $arFields[""PASSWORD""];
		        }
			
		        $objUser->Update($userID, $fields);
                $res = $objUser->Login($arUser[""EMAIL""], $newPassword);
		        if (!is_array($res)) {
			        echo ""Успешная авторизация"";
		        } else {
			        echo ""Авторизация не удалась:\n"";
			        print_r($res);
		        }";
            var phpExecutor = new PHPcommandLineExecutor(portalUri, adminUser.LoginAkaEmail, adminUser.Password);
            string execResult = phpExecutor.Execute(php);
            if(execResult?.Contains("Успешная авторизация") != true)
                throw new Exception($"В ходе установки пароля для {user.LoginAkaEmail} что-то пошло не так :( \r\n: {execResult}");
        }

        static void ConfirmEmail(User userToConfirm, Uri portalUri, User portalAdmin)
        {
            PortalDatabaseExecutor.ExecuteQuery("UPDATE b_user SET CONFIRM_CODE = '' WHERE LOGIN = '" + userToConfirm.LoginAkaEmail + "'", portalUri, portalAdmin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetUserId"></param>
        /// <param name="portalUri"></param>
        /// <param name="userToAuth"></param>
        /// <returns>Список id через запятую без пробелов</returns>
        static string GetUserGroupIds(string targetUserId, Uri portalUri, User userToAuth)
        {
            var groupsIDs = PortalDatabaseExecutor.ExecuteQuery("SELECT GROUP_ID from b_user_group WHERE USER_ID = '" + targetUserId + "'", portalUri, userToAuth);
            if (groupsIDs.Count == 0)
                throw new Exception("Не удалось получить группы пользователя");
            string concatIds = string.Join(",", groupsIDs.Select(x => x.GROUP_ID));
            return concatIds;
        }

        static int generatedEmailCounter = 0;
        /// <summary>
        /// Генерация названия почтового ящика на основе данных пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <returns></returns>
        public static string GenerateEmail(string name, string lastName, string mailPostfix = "test.com")
        {
            generatedEmailCounter++;
            string n = name != default && name.Length > 3 ? name[0..4] : name;
            string ln = lastName != default && lastName.Length > 2 ? lastName[0..3] : lastName;
            return ("bx" + generatedEmailCounter + Transliteration.Front(n).ToLower() + Transliteration.Front(ln).ToLower() + "-" +
                    DateTime.Now.ToString("ddMMyyyyhhmmss") + "@" + mailPostfix);
        }

        public static string GetPassword()
        {
            return BxPwdGenerator(8) + ",aA1";//приписочка чтобы соответствовать стоковой политике безопасности паролей
        }

        static int lastGeneratedTicks = default;
        static string BxPwdGenerator(int length, int intervalCharStart = 33, int intervalCharEnd = 125)
        {
            if (lastGeneratedTicks == default)
                lastGeneratedTicks = new Random().Next() / 2;//пополам чтобы не вылететь за границы при инкременте
            lastGeneratedTicks++;
            Random rnd = new Random(lastGeneratedTicks);
            string result = "";
            for (int i = 0; i < length; i++)
                result += (char)rnd.Next(intervalCharStart, intervalCharEnd);
            result = result.Replace("'", "%");//сделано видимо было чтобы не рассыпался GET запрос, но также работает и для генерации линуксовых паролей через bash, чтобы не экранировать одинарную кавычку в строке взятой в одинарные кавычки
            result = result.Replace("%", "0");//сделано чтобы избежать полного краха авторизаций в ios
            if (result.StartsWith('^'))
                result = result.Replace("^", "A");//сделано потому что почта не дает подключать ящики, у которых пароль начинается с ^
            return result;
        }

        public static User GenerateBxPortalValidUserData(string namePrefix = default, string lastNamePrefix = default)
        {
            var tdStock = new List<string> { "Иван", "Чё" };
            var tdFinal = new List<string> { namePrefix, lastNamePrefix };
            int maxNameLength = 22;

            for (int i = 0; i < tdFinal.Count; i++)
            {
                if (tdFinal[i] == default)
                    tdFinal[i] = tdStock[i];
                if (tdFinal[i].Length > maxNameLength)
                    tdFinal[i] = tdFinal[i][..maxNameLength];
                else
                {
                    int saltMaxLength = maxNameLength - tdFinal[i].Length;
                    if (saltMaxLength > 0)
                        tdFinal[i] = tdFinal[i] + HelperMethods.GetDateTimeSaltString(true, saltMaxLength);
                }
            }

            var coreUser = GenerateUserData(tdFinal[0], tdFinal[1]);
            return coreUser;
        }

        static User GenerateUserData(string name, string lastName)
        {
            var user = new User();
            user.Name = name;
            user.LastName = lastName;
            user.Password = GetPassword();
            user.LoginAkaEmail = GenerateEmail(name, lastName);
            return user;
        }
    }
}
