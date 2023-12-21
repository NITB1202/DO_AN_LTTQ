using DO_AN_LTTQ.Forms;

namespace DO_AN_LTTQ
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            splash_screen splash_Screen = new splash_screen();
            Application.Run(splash_Screen);
            if(splash_Screen.IsDisposed)
                Application.Run(new start_page());

        }
    }
}