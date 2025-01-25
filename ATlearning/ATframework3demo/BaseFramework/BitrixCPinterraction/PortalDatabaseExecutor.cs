using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.TestEntities;
using Newtonsoft.Json;

namespace ATframework3demo.BaseFramework.BitrixCPinterraction
{
    public class PortalDatabaseExecutor
    {
        /// <summary>
        /// Позволяет выполнять запросы в базу портала через админку
        /// </summary>
        /// <param name="query"></param>
        /// <param name="portalUri"></param>
        /// <param name="portalAdmin"></param>
        /// <returns>Список строк</returns>
        public static List<dynamic> ExecuteQuery(string query, Uri portalUri, User portalAdmin)
        {
            var phpExecutor = new PHPcommandLineExecutor(portalUri, portalAdmin.LoginAkaEmail, portalAdmin.Password);
            string php = "global $DB;\r\n" +
                $"$res = $DB->Query(\"{query}\");";
            php += @"
            $rows = [];
            while ($row = $res->Fetch()) 
	            $rows[] = $row;
            echo json_encode($rows);";
            string json = phpExecutor.Execute(php);
            return JsonConvert.DeserializeObject<List<dynamic>>(json);
        }
    }
}
