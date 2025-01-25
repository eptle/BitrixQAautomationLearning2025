using ATframework3demo.SeleniumFramework.DriverActions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace atFrameWork2.SeleniumFramework
{
    public class MobileDriverActions : BaseDriverActions
    {
        /// <summary>
        /// Создает настроенный объект мобильного драйвера
        /// </summary>
        /// <returns></returns>
        public static AppiumDriver GetNewMobileDriver()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.PlatformName = "Android";
            appiumOptions.AutomationName = "UiAutomator2"; // Драйвер для автоматизации
            appiumOptions.App = "/path/to/your/bitrix24_stable.apk"; // Путь к приложению
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.Udid, "emulator-5554"); // Уникальный идентификатор устройства
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.NoReset, false); // Не сбрасывать состояние приложения
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.FullReset, false); // Выполнить полный сброс состояния
            appiumOptions.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 60); // Таймаут для новой команды
            appiumOptions.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AutoGrantPermissions, true); // Автоматом подтверждает уведомления
            var appiumHost = "http://127.0.0.1:4723";
            AppiumDriver driver = new AndroidDriver(new Uri($"{appiumHost}/"), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
