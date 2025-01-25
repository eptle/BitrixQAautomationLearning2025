using atFrameWork2.BaseFramework.LogTools;

namespace atFrameWork2.BaseFramework
{
    public class Waiters
    {
        /// <summary>
        /// С заданным интервалом выполняет код из <paramref name="conditionMethod"/> до тех пор пока он не вернёт true либо до истечения таймаута ожидания.
        /// </summary>
        /// <param name="conditionMethod"></param>
        /// <param name="retryInterval_s"></param>
        /// <param name="timeout_s"></param>
        /// <param name="waitDescription"></param>
        /// <returns></returns>
        public static bool WaitForCondition(Func<bool> conditionMethod, int retryInterval_s, int timeout_s, string waitDescription)
        {
            var limitTime = DateTime.Now.AddSeconds(timeout_s);
            LogTools.Log.Info(waitDescription);

            while (true)
            {
                if (DateTime.Now <= limitTime)
                {
                    try
                    {
                        if (conditionMethod.Invoke())
                            return true;
                    }
                    catch (Exception) { }

                    Thread.Sleep(retryInterval_s * 1000);
                }
                else
                {
                    Log.Info("Достигнут таймаут ожидания");
                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Приостанавливает выполнение потока на заданное количество секунд
        /// </summary>
        /// <param name="secondsToWait"></param>
        public static void StaticWait_s(int secondsToWait)
        {
            Thread.Sleep(secondsToWait * 1000);
        }
    }
}
