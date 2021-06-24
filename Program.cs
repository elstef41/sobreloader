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
            SC.mensajeInicio();
            Application.Run(new sobreloader());
        }
    }
}
