using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sobreloader
{
    public partial class ejemplos : Form
    {
        public ejemplos()
        {
            InitializeComponent();
        }

        private void ejemplos_Load(object sender, EventArgs e)
        {
            this.Size = new Size(249, 219);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Size.Width != 554 || this.Size.Height != 219)
            {
                this.Size = new Size(554, 219);
            }
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    labelNom.Text = "Paint";
                    labelDesc.Text = "El clásico editor de imágenes preinstalado en Windows.";
                    labelWW.Text = "Todos";
                    break;
                case 1:
                    labelNom.Text = "Bloc de notas";
                    labelDesc.Text = "Editor de texto sin formato simple y sencillo.";
                    labelWW.Text = "Todos";
                    break;
                case 2:
                    labelNom.Text = "WordPad";
                    labelDesc.Text = "Editor de texto en formato enriquecido, muy básico en comparación con Word pero más completo que el Bloc de Notas. ¿Qué más se puede pedir?";
                    labelWW.Text = "Todos";
                    break;
                case 3:
                    labelNom.Text = "Internet Explorer";
                    labelDesc.Text = "De los navegadores de Internet que pasaron a la historia. En su momento llegó a ser el más utilizado, superando a Netscape. Hoy en día te permite descargar otros como el.";
                    labelWW.Text = "Hasta Windows 10";
                    break;
                case 4:
                    labelNom.Text = "Explorador de archivos";
                    labelDesc.Text = "La herramienta más usada de Microsoft Windows.";
                    labelWW.Text = "Todos";
                    break;
                case 5:
                    labelNom.Text = "Mapa de carácteres";
                    labelDesc.Text = "Si necesitas buscar e insertar símbolos extraños, o si vas a mandar un correo y tu bendito teclado no te permite insertar la arroba, esta utilidad preinstalada te sirve de maravilla.";
                    labelWW.Text = "Todos";
                    break;
                case 6:
                    labelNom.Text = "Administrador de tareas";
                    labelDesc.Text = "Este invento de David Plummer funciona para cerrar aquellas aplicaciones molestas que se nos cuelgan, ¡Vaya!";
                    labelWW.Text = "Todos";
                    break;
                case 7:
                    labelNom.Text = "Panel de control";
                    labelDesc.Text = "El centro de las principales configuraciones del sistema operativo de Microsoft. Presente desde siempre.";
                    labelWW.Text = "Todos";
                    break;
                default:
                    labelNom.Text = "Programa desconocido";
                    labelDesc.Text = "";
                    labelWW.Text = "??";
                    break;

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var proceso = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = listBox1.SelectedItem.ToString(),
                    RedirectStandardOutput = false,
                    CreateNoWindow = true,
                }
            };
            try
            {
                proceso.Start();
            }
            catch (SystemException err)
            {
                MessageBox.Show("Ha ocurrido un error al abrir el archivo. Comprueba que es compatible con tu versión de Windows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
