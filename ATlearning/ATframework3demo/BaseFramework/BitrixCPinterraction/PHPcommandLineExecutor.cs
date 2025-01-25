using AquaCore.General;
using atFrameWork2.BaseFramework.LogTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace AquaTestFramework.CommonFramework.BitrixCPinteraction
{
    /// <summary>
    /// Выполняет php код через "Командная PHP-строка" в админке
    /// </summary>
    public class PHPcommandLineExecutor
    {
        public PHPcommandLineExecutor(Uri siteUri, string adminLogin, string adminPassword)
        {
            SiteUri = siteUri;
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
        }

        public Uri SiteUri { get; }
        public string AdminLogin { get; }
        public string AdminPassword { get; }
        Uri PHPcommandLineGetUri => new Uri($"{SiteUri}bitrix/admin/php_command_line.php?lang=ru");

        public string Execute(string phpCode)
        {
            Log.Info($"Попытка выполнить php:\r\n{phpCode}");
            HttpClient client = GetAuthorisedHttpClient(out string bitrix_sessid);
            string result =  MakeRequestToPHPconsole(phpCode, client, bitrix_sessid);
            Log.Info($"Результат выполнения php:\r\n{result}");
            return result;
        }

        private static string MakeRequestToPHPconsole(string phpCode, HttpClient client, string bitrix_sessid)
        {
            var rqParameters = new List<KeyValuePair<string, string>>();
            rqParameters.Add(new KeyValuePair<string, string>("query", phpCode));
            rqParameters.Add(new KeyValuePair<string, string>("result_as_text", "y"));
            rqParameters.Add(new KeyValuePair<string, string>("ajax", "y"));
            rqParameters.Add(new KeyValuePair<string, string>("sessid", bitrix_sessid));
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "");
            requestMessage.Content = new FormUrlEncodedContent(rqParameters);
            var response = client.SendAsync(requestMessage).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode != HttpStatusCode.OK || responseBody?.Contains("Время выполнения:") != true)
                throw new Exception("php-код не выполнен, ответ сервера:\r\n" + responseBody);

            string phpCodeResult = default;
            if (responseBody != null)
            {
                phpCodeResult = HttpUtility.HtmlDecode(responseBody);
                if (phpCodeResult.Contains("<pre>"))
                {
                    phpCodeResult = HtmlTools.GetItemInnerTextFromHtml(new List<string> { "//pre" }, responseBody, true);
                    phpCodeResult = HttpUtility.HtmlDecode(phpCodeResult);
                }
            }

            return phpCodeResult;
        }

        private HttpClient GetAuthorisedHttpClient(out string bitrix_sessid)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            var client = new HttpClient(handler) { BaseAddress = PHPcommandLineGetUri };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.ConnectionClose = true;
            var rqParameters = new List<KeyValuePair<string, string>>();
            rqParameters.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            var content = new FormUrlEncodedContent(rqParameters);
            var authenticationString = $"{AdminLogin}:{AdminPassword}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationString));
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            requestMessage.Content = content;
            var response = client.SendAsync(requestMessage).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            bitrix_sessid = ParseBitrixSessid(responseBody);
            if (string.IsNullOrEmpty(bitrix_sessid))
                throw new Exception("Не удалось получить " + nameof(bitrix_sessid));
            return client;
        }

        /// <summary>
        /// Получает bitrix_sessid из html ответа
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ParseBitrixSessid(string html)
        {
            string sessid = default;
            string anchor = "var phpVars = {";//админка
            int startIndex = html.IndexOf(anchor);

            if (startIndex != -1)
            {
                html = html.Substring(startIndex);
                var res = html.TakeWhile(x => x != '}').ToArray();
                string clean = new string(res);
                var splitted = clean.Split('\n').ToList();
                string sidString = splitted.Find(x => x.Contains("bitrix_sessid"));
                sessid = sidString.Split(':')[1].Trim().Replace(",", "").Replace("'", "");
            }
            else
            {
                string[] anchors = {
                        "(window.BX||top.BX).message({'LANGUAGE_ID':",// публичка коробки(а может и Б24)
                        "(window.BX||top.BX).message({\"LANGUAGE_ID\":"// 24.06.2024 "LANGUAGE_ID" теперь в двойных кавычках
                    };

                foreach (string item in anchors)
                {
                    startIndex = html.IndexOf(item);
                    if (startIndex != -1)
                    {
                        string idTitle = "bitrix_sessid";
                        var lines = html.Split('\n').ToList();
                        var targetLine = lines.Find(x => !string.IsNullOrEmpty(x) && x.Contains(item) && x.Contains(idTitle));

                        if (targetLine != default)
                        {
                            // Удаляем все символы до начала idTitle и заменяем "'idTitle':'" или "\"idTitle\":\"" на пустую строку
                            string tale = targetLine.Remove(0, targetLine.IndexOf(idTitle) - 1)
                                .Replace("'" + idTitle + "':'", "")
                                .Replace("\"" + idTitle + "\":\"", "");
                            // Извлекаем значение до первой двойной кавычки или апострофа
                            int endIndex = tale.IndexOfAny(['\'', '"']);
                            if (endIndex != -1)
                            {
                                sessid = tale.Remove(endIndex);
                                break;
                            }
                        }
                    }
                }
            }

            return sessid;
        }
    }
}
