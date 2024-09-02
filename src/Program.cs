namespace WinSerialPorts
{
    internal static class Program
    {
        public static string Version = "1.0.0";
        public static int BuildNumber = 5;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Form form = new frmSerialPorts();
            if (args.Length > 0) 
            {
                if (args[0] == "/minimize")
                {
                    form.WindowState = FormWindowState.Minimized;
                }
            }
            Application.Run(form);
        }
    }
}