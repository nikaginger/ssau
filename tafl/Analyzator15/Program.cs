namespace Analyzator15
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
            // ApplicationConfiguration.Initialize();
            // Application.Run(new Form1());
            Console.WriteLine("¬ведите строку дл€ анализа: ");
            string str = Console.ReadLine();
            Console.WriteLine(Analyzer.Analyze(s: str));

        }
    }
}