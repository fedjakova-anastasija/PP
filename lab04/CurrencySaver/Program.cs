using System;
using System.Windows.Forms;
using CurrencySaver.ViewModels;

namespace CurrencySaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            WindowViewModel windowView = new WindowViewModel();
            Window window = new Window(windowView);

            Application.Run(window);
        }
    }
}
