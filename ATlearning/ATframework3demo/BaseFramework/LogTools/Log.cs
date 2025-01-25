using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace atFrameWork2.BaseFramework.LogTools
{
    class Log
    {
        const string logHeader = "<!DOCTYPE html>";
        public const string commonLogPath = "log.html";
        public static void WriteHtmlHeader(string filePath)
        {
            if(!File.Exists(filePath))
                File.WriteAllText(filePath, Log.logHeader);
        }

        public static void Info(string message)
        {
            Add(new LogMessageInfo(message));
        }

        public static void Error(string message)
        {
            Add(new LogMessageError(message));
        }

        static void Add(LogMessage message)
        {
            string recordContent = $"[{DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fff")}][{message.MsgType}] {message.Text}";
            var runningTestCase = TestCase.RunningTestCase;
            message.WriteHtml(runningTestCase == default ? commonLogPath : runningTestCase.CaseLogPath, recordContent);
            if(runningTestCase != default)
                runningTestCase.CaseLog.Add(message);
        }
    }
}
