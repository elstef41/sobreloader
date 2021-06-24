using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Sobreloader
{
    class Strings
    {
        public string obtenerVersion()
        {
            string s = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            return s;
        }
        public DialogResult mensajeInicio()
        {
            return MessageBox.Show("Esta sencilla herramienta fue creada con fines educativos y para todo aquel que quisiera probar el método de sobrecarga. Se aconseja su utilización en entornos virtualizados, tales como máquinas virtuales.\n\nEl autor de este programa no se hace responsable de los efectos que pueda conllevar su ejecución. Úsalo con precaución.", "elstef41 Sobreloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
