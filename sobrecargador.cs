using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace Sobreloader
{
    public partial class sobreloader : Form
    {
        Strings SC = new Strings();
        public sobreloader()
        {
            InitializeComponent();
            this.MinimumSize = new Size(396, 249);
            this.Text = "Sobreloader ";
            this.Text += SC.obtenerVersion();
            this.Text += " por elstef41";
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 1000)
            {
                panel2.Visible = true;
                int tsHeightM = this.Size.Height + 10;
                this.Size = new Size(this.Size.Width, tsHeightM);
            }
            else
            {
                panel2.Visible = false;
                this.Size = new Size(this.Size.Width, 396);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("No has escrito un proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numericUpDown1.Value < 1)
            {
                MessageBox.Show("La cantidad debe ser superior a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int eCant = Convert.ToInt32(numericUpDown1.Value);
                int eAb = 0;
                ProcessWindowStyle SelVent;
                string args = argsTB.Text;
                if (checkBox1.Checked == true)
                {
                    SelVent = ProcessWindowStyle.Maximized;
                }
                else
                {
                    SelVent = ProcessWindowStyle.Normal;
                }
                var procesos = Process.GetProcessesByName(textBox1.Text);
                if (!checkBox1.Checked)
                {
                    args = "";
                }
                while (eAb < eCant)
                {
                    var proceso = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = textBox1.Text,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true,
                            Arguments = args
                        }
                    };
                    try
                    {
                        proceso.Start();
                        eAb++;
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("No se ha encontrado el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        eAb = eCant;
                    }
                    catch (SystemException)
                    {
                        MessageBox.Show("Ha occurido un error al abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        eAb = eCant;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (checkBox1.Checked)
            {
                case true:
                    argsTB.Visible = true;
                    break;
                default:
                    argsTB.Visible = false;
                    break;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void visitarRepositorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            System.Diagnostics.Process.Start("https://twitter.com/elstef41");
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AcercaDe().ShowDialog();
        }


        private void advertenciaDeInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SC.mensajeInicio();
        }


        private void nombresDeEjemploToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sobreloader.ejemplos().Show();
        }

        private void visitarRepositorioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/elstef41/sobreloader");
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("No has escrito un proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (numericUpDown1.Value < 1)
                {
                    MessageBox.Show("La cantidad debe ser superior a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int eCant = Convert.ToInt32(numericUpDown1.Value);
                    int eAb = 0;
                    ProcessWindowStyle SelVent;
                    string args = argsTB.Text;
                    if (checkBox1.Checked == true)
                    {
                        SelVent = ProcessWindowStyle.Maximized;
                    }
                    else
                    {
                        SelVent = ProcessWindowStyle.Normal;
                    }
                    var procesos = Process.GetProcessesByName(textBox1.Text);
                    if (!checkBox1.Checked)
                    {
                        args = "";
                    }
                    while (eAb < eCant)
                    {
                        var proceso = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = textBox1.Text,
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true,
                                Arguments = args
                            }
                        };
                        try
                        {
                            proceso.Start();
                            eAb++;
                        }
                        catch
                        {
                            MessageBox.Show("El archivo especificado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            eAb = eCant;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirEXE = new OpenFileDialog();
            abrirEXE.Title = "Selecciona el archivo";
            abrirEXE.Filter = "Ejecutables|*.exe";
            Stream archivoEXE = null;
            if (abrirEXE.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!abrirEXE.FileName.EndsWith(".EXE") && !abrirEXE.FileName.EndsWith(".exe")) {
                        MessageBox.Show("Por favor, selecciona un ejecutable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if ((archivoEXE = abrirEXE.OpenFile()) != null)
                    {
                        using (archivoEXE) 
                        {
                            textBox1.Text = abrirEXE.FileName;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha ocurrido un error al abrir el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void guardarEnArchivoDeLotesbatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}

namespace Sobreloader
{
    class Form1
    {
    }
}
