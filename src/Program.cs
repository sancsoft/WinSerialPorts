namespace WinSerialPorts
{
    internal static class Program
    {
        public static string Version = "1.0.0";
        public static int BuildNumber = 4;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSerialPorts());
        }
    }
}