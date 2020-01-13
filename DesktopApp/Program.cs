using DesktopApp.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>

        private static readonly MySimpleInjector _simpleInjector = new MySimpleInjector();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _simpleInjector.Register();
            Application.Run(_simpleInjector.MainViewInstance);
        }
    }
}
