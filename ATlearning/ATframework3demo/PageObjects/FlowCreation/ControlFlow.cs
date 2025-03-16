using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Flows;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.FlowCreation
{
    public class ControlFlow
    {
        public ControlFlow(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Нажать кнопку "создать поток" снизу слайдера
        /// </summary>
        public FlowsPage CreateFlow()
        {
            var createFlowBtn = new WebItem(
                "//button[@class='ui-btn ui-btn-lg ui-btn-primary ui-btn-round']",
                "Кнопка Создать поток внизу");
            createFlowBtn.Click();
            return new FlowsPage();
        }
    }
}
