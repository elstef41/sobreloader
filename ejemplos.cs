using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Resources;

namespace Sobreloader
{
    public partial class ejemplos : Form
    {
        ResourceManager rm = new ResourceManager(typeof(ejemplos));
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
                    labelNom.Text = string.Format(rm.GetString("1T"));
                    labelDesc.Text = string.Format(rm.GetString("1D"));
                    labelWW.Text = string.Format(rm.GetString("1W"));
                    break;
                case 1:
                    labelNom.Text = string.Format(rm.GetString("2T"));
                    labelDesc.Text = string.Format(rm.GetString("2D"));
                    labelWW.Text = string.Format(rm.GetString("2W"));
                    break;
                case 2:
                    labelNom.Text = string.Format(rm.GetString("3T"));
                    labelDesc.Text = string.Format(rm.GetString("3D"));
                    labelWW.Text = string.Format(rm.GetString("3W"));
                    break;
                case 3:
                    labelNom.Text = string.Format(rm.GetString("4T"));
                    labelDesc.Text = string.Format(rm.GetString("4D"));
                    labelWW.Text = string.Format(rm.GetString("4W"));
                    break;
                case 4:
                    labelNom.Text = string.Format(rm.GetString("5T"));
                    labelDesc.Text = string.Format(rm.GetString("5D"));
                    labelWW.Text = string.Format(rm.GetString("5W"));
                    break;
                case 5:
                    labelNom.Text = string.Format(rm.GetString("6T"));
                    labelDesc.Text = string.Format(rm.GetString("6D"));
                    labelWW.Text = string.Format(rm.GetString("6W"));
                    break;
                case 6:
                    labelNom.Text = string.Format(rm.GetString("7T"));
                    labelDesc.Text = string.Format(rm.GetString("7D"));
                    labelWW.Text = string.Format(rm.GetString("7W"));
                    break;
                default:
                    labelNom.Text = string.Format(rm.GetString("8T"));
                    labelDesc.Text = string.Format(rm.GetString("8D"));
                    labelWW.Text = string.Format(rm.GetString("8W"));
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
