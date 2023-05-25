namespace MineSweeperPro
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

            string homeFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string appFolderPath = Path.Combine(homeFolderPath, "Pyrobolum");

            if (!Directory.Exists(appFolderPath))
            {
                Directory.CreateDirectory(appFolderPath);
            }

            Application.Run(new Main());
        }
    }
}