using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace ATframework3demo.SeleniumFramework.DriverActions
{
    public class BaseDriverActions
    {
        public static void ExecuteJS(string scriptCode, IWebDriver driver = default)
        {
            Log.Info($"{nameof(ExecuteJS)}: попытка выполнить скрипт:\r\n{scriptCode}");
            driver ??= WebItem.DefaultDriver;
            driver.ExecuteJavaScript(scriptCode);
        }
    }
}
