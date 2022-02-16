using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sobreloader;

namespace Sobreloader
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Strings SC = new Strings();
            if (Properties.Settings.Default.IsFirstLaunch)
            {
                Properties.Settings.Default.IsFirstLaunch = false;
                Properties.Settings.Default.Save();
                SC.mensajeInicio();
            }
            Application.Run(new sobreloader());
        }
    }
}
