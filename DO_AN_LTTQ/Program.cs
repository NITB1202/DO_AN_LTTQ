namespace DO_AN_LTTQ
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new workplace());
        }
    }
}