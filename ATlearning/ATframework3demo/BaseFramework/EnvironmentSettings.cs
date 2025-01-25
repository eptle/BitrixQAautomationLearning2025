namespace ATframework3demo.BaseFramework
{
    public class EnvironmentSettings
    {
        public static List<string> AppArgs { get; set; } = new List<string>();
        public static bool IsDebug => AppArgs.Contains("debug");
    }
}
