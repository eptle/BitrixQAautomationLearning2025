using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Поле для прикрепление файла, которое не обладает стандартным инпутом типа файл. Пример такого поля в форме прикрепления файла у посту живой ленты.
    /// Работает через имитацию драг эн дропа.
    /// </summary>
    public class BitrixMagicFileInput
    {
        const string inputId = "ui-tile-uploader-file-proxy";

        string fakeFileJS = @"(function(targetSelector) {
                const dropFile = (target, file) => {
                    const dataTransfer = new DataTransfer();
                    dataTransfer.items.add(file);
                    const event = new DragEvent('drop', { dataTransfer, bubbles: false });
                    target.dispatchEvent(event);
                };

                const target = document.querySelector(targetSelector);
                console.log('target', target);
                const input = document.createElement('input');
                input.type = 'file';
                input.id = '" + inputId + @"';
                input.onchange = function (event) {
                    const file = this.files[0];
                    console.log('file', file);
                    dropFile(target, file);
                    document.body.removeChild(input);
                };
                document.body.appendChild(input);
                })";
        
        string dropZoneClass;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dropZoneClass">Значение атрибута class у элемента области на которую можно выполнить физический драгэндроп</param>
        public BitrixMagicFileInput(string dropZoneClass = "disk-user-field-control:not([style*='display:none']):not([style*='display: none']) .ui-tile-uploader")
        {
            this.dropZoneClass = dropZoneClass;
            fakeFileJS += $"(\".{this.dropZoneClass}\")";
        }

        public void UploadFile(string localFileAbsolutePath)
        {
            if (File.Exists(localFileAbsolutePath))
            {
                WebDriverActions.ExecuteJS(fakeFileJS);
                new WebItem($"//input[@id='{inputId}']", "Фейковый инпут для ввода пути к файлу").SendKeys(localFileAbsolutePath); 
            }
            else
                throw new FileNotFoundException(localFileAbsolutePath + " не найден");
        }
    }
}
