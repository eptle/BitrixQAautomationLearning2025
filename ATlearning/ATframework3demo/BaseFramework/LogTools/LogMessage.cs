using ATframework3demo.BaseFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace atFrameWork2.BaseFramework.LogTools
{
    public abstract class LogMessage
    {
        public string MsgType { get; protected set; }
        public string Text { get; protected set; }
        Color MessageColor { get; set; }

        protected LogMessage(string msgType, string text, Color messageColor)
        {
            MsgType = msgType ?? throw new ArgumentNullException(nameof(msgType));
            Text = text;
            MessageColor = messageColor;
        }

        public void WriteHtml(string filePath, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string hexColor = HelperMethods.GetHexColor(MessageColor);
                string htmlToWrite = GetFormattedLine(text, hexColor);

                if (text?.Contains('\n') == true)
                {
                    var msgLines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    htmlToWrite = String.Join(Environment.NewLine, msgLines.Select(x => GetFormattedLine(x, hexColor)));
                }

                File.AppendAllText(filePath, htmlToWrite + Environment.NewLine);
            }
        }

        private static string GetFormattedLine(string text, string hexColor)
        {
            return $"<div style=\"color: {hexColor}\">{text?.Trim()}</div>";
        }
    }
}
