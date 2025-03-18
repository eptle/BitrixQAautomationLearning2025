using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile.More.CRM
{
    public class DealWizard
    {
        public DealWizard ScrollUp(int xCoord)
        {
            MobileDriverActions.ExecuteJS(
                """"
                                // Функция для создания touch события
                function createTouchEvent(type, x, y, identifier = 0) {
                    const touch = new Touch({
                        identifier: identifier,
                        target: document.elementFromPoint(x, y),
                        clientX: x,
                        clientY: y,
                        radiusX: 2.5,
                        radiusY: 2.5,
                        rotationAngle: 10,
                        force: 0.5
                    });

                    return new TouchEvent(type, {
                        cancelable: true,
                        bubbles: true,
                        touches: [touch],
                        targetTouches: type === 'touchend' ? [] : [touch],
                        changedTouches: [touch]
                    });
                }

                // Начальная точка
                const startX = 100;
                const startY = 1000;

                // Конечная точка
                const endX = 100;
                const endY = 100;

                // Элемент, на котором будут происходить события
                const targetElement = document.elementFromPoint(startX, startY);

                // Шаги для симуляции движения
                const steps = 50; // Количество шагов
                const stepX = (endX - startX) / steps;
                const stepY = (endY - startY) / steps;

                // Симуляция touchstart
                let currentX = startX;
                let currentY = startY;
                targetElement.dispatchEvent(createTouchEvent('touchstart', currentX, currentY));

                // Симуляция движения (touchmove)
                for (let i = 0; i <= steps; i++) {
                    currentX += stepX;
                    currentY += stepY;

                    // Добавляем задержку для более реалистичного движения
                    setTimeout(() => {
                        targetElement.dispatchEvent(createTouchEvent('touchmove', currentX, currentY));
                    }, i * 10); // Задержка между шагами (10 мс)
                }

                // Симуляция touchend
                setTimeout(() => {
                    targetElement.dispatchEvent(createTouchEvent('touchend', endX, endY));
                }, steps * 10);
                """"
                );
            return new DealWizard();
        }

        public DealWizard EnterTitle(string title)
        {
            var titleField = new MobileItem(
                "//android.widget.TextView[@content-desc=\"deal_0_details_editor_TITLE_NAME\"]",
                "поле названия сделки");
            titleField.Click();

            var inputField = new MobileItem(
                "//android.widget.EditText[@text=\"Сделка #\"]",
                "поле написания названия сделки");
            inputField.SendKeys(title);

            var saveBtn = new MobileItem(
                "//android.widget.TextView[@text=\"Сохранить\"]",
                "кнопка сохранить");
            saveBtn.Click();

            return new DealWizard();
        }

        public DealWizard AddFirstContact()
        {
            var addContactsBtn = new MobileItem(
                "//android.widget.TextView[@text=\"Добавить контакт\"]",
                "добавить контакты");
            addContactsBtn.Click();

            var firstContact = new MobileItem(
                "(//android.widget.ImageView[@resource-id=\"com.bitrix24.android:id/badged_icon\"])[9]",
                "выбрать человека");
            firstContact.Click();

            var chooseBtn = new MobileItem(
                "//android.widget.FrameLayout[@resource-id=\"com.bitrix24.android:id/apply_button\"]",
                "кнопка выбрать");
            chooseBtn.Click();

            return new DealWizard();
        }

        public DealWizard SetSum(int sum)
        {
            var inputField = new MobileItem(
                "//android.widget.EditText[@text=\"0\"]",
                "поле сумма сделки");
            inputField.SendKeys(sum.ToString());
            return new DealWizard();
        }

        public DealWizard AddWatchers()
        {
            var addWatchersBtn = new MobileItem(
                "//android.view.ViewGroup[@content-desc=\"deal_0_details_editor_OBSERVER_FIELD\"]/android.view.ViewGroup",
                "добавить наблюдателей");
            addWatchersBtn.Click();

            var firstContact = new MobileItem(
                "(//android.widget.ImageView[@resource-id=\"com.bitrix24.android:id/badged_icon\"])[9]",
                "выбрать человека");
            firstContact.Click();

            var chooseBtn = new MobileItem(
                "//android.widget.FrameLayout[@resource-id=\"com.bitrix24.android:id/apply_button\"]",
                "кнопка выбрать");
            chooseBtn.Click();

            return new DealWizard();
        }

        public DealWizard TypeComment(string title)
        {
            var titleField = new MobileItem(
                "//android.widget.TextView[@content-desc=\"deal_0_details_editor_COMMENTS_NAME\"]",
                "Комментарий");
            titleField.Click();

            var inputField = new MobileItem(
                "//android.widget.EditText[@text=\"Заполнить\"]",
                "поле написания названия сделки");
            inputField.SendKeys(title);

            var saveBtn = new MobileItem(
                "//android.widget.TextView[@text=\"Сохранить\"]",
                "кнопка сохранить");
            saveBtn.Click();

            return new DealWizard();
        }

        public DealCard CreateDeal()
        {
            var titleField = new MobileItem(
                "//android.widget.TextView[@text=\"Создать\"]",
                "кнопка создать сверху слева");
            titleField.Click();

            return new DealCard();
        }
    }
}
