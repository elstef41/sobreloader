using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Resources;

namespace Sobreloader
{
    public partial class sobreloader : Form
    {
        Strings SC = new Strings();
        ResourceManager rm = new ResourceManager(typeof(sobreloader));
        public List<String> prgsList = new List<String>();

        public string consejosFrases()
        {
            string[] ejemplos = {"mspaint", "notepad", "winver", "calc"};
            var ejaltr = new Random();
            int cntej = ejaltr.Next(ejemplos.Length);
            return ejemplos[cntej];
        }


        public sobreloader()
        {
            InitializeComponent();
            this.MinimumSize = new Size(430, 350);
            this.Text = "Sobreloader ";
            this.Text += SC.obtenerVersion();
            this.Text += rm.GetString("nby");
            label3.Text = rm.GetString("nex") + consejosFrases();
            restaurarVentanaToolStripMenuItem.Enabled = false;
        }
        string ultexto;
        bool ultextoUso = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            int sl = 1;
            if (textBox1.Text == "")
            {
               MessageBox.Show(string.Format(rm.GetString("msgNoProcess")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox2.Checked == false && numericUpDown1.Value < 1)
                {
                    MessageBox.Show(string.Format(rm.GetString("msgAmount1")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    if (checkBox2.Checked == true)
                    {
                        var sinlimconfirm = MessageBox.Show(string.Format(rm.GetString("msgNoLimit")), rm.GetString("msgWarn"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        switch (sinlimconfirm)
                        {
                            case DialogResult.Yes:
                                sl = 1;
                                break;
                            case DialogResult.No:
                                sl = 0;
                                break;
                        }
                    }
                    if (sl == 1)
                    {
                        int eCant = Convert.ToInt32(numericUpDown1.Value);
                        int eAb = 0;
                        string args = argsTB.Text;
                        ProcessWindowStyle wst = ProcessWindowStyle.Normal;
                        if (radioButton2.Checked)
                        {
                            wst = ProcessWindowStyle.Minimized;
                        }
                        else if (radioButton3.Checked)
                        {
                            wst = ProcessWindowStyle.Maximized;
                        }
                        else if (radioButton4.Checked)
                        {
                            wst = ProcessWindowStyle.Hidden;
                        }
                        var procesos = Process.GetProcessesByName(textBox1.Text);
                        if (!checkBox1.Checked)
                        {
                            args = "";
                        }
                        ultexto = textBox1.Text;
                        ultextoUso = true;
                        desText.Visible = false;
                        string prgsText;
                        switch (checkBox2.Checked)
                        {
                            case true:
                                prgsText = textBox1.Text + rm.GetString("nlt");
                                break;
                            default:
                                prgsText = textBox1.Text + " - " + eCant;
                                break;
                        }
                        prgsList.Add(prgsText);
                        while (eAb < eCant)
                        {
                            var proceso = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = textBox1.Text,
                                    WindowStyle = wst,
                                    RedirectStandardOutput = false,
                                    CreateNoWindow = true,
                                    UseShellExecute = true,
                                    Arguments = args
                                }
                            };
                            try
                            {
                                proceso.Start();
                                if (checkBox2.Checked == false) { eAb++; }
                            }
                            catch (SystemException err)
                            {
                                if (SC.debug)
                                {
                                    MessageBox.Show(string.Format(rm.GetString("msgErrorOF")) + "\n\n" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show(string.Format(rm.GetString("msgErrorOF")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                eAb = eCant;
                            }
                        }
                        if (checkBox3.Checked)
                        {
                            this.Close();
                        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirEXE = new OpenFileDialog();
            abrirEXE.Title = string.Format(rm.GetString("textOFD"));
            abrirEXE.Filter = string.Format(rm.GetString("textEx"));
            Stream archivoEXE = null;
            if (abrirEXE.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!abrirEXE.FileName.EndsWith(".EXE") && !abrirEXE.FileName.EndsWith(".exe")) {
                        MessageBox.Show(string.Format(rm.GetString("msgErrorSE")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(string.Format(rm.GetString("msgErrorOpen")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown1.Enabled = false;
                checkBox3.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void licenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.apache.org/licenses/LICENSE-2.0.html");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label3.Visible = false;
                cancText.Visible = true;
                if (ultextoUso)
                {
                    desText.Visible = true;
                }
                else
                {
                    desText.Visible = false;
                }
            }
            else
            {
                if (!cancText.Visible)
                {
                    label3.Visible = true;
                }
                cancText.Visible = false;
            }
            if (ultextoUso == true && ultexto == textBox1.Text)
            {
                desText.Visible = false;
            }
        }

        private void sobreloader_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                restaurarVentanaToolStripMenuItem.Enabled = false;

            }
            else if (this.Size.Width != 450 || this.Size.Height != 356)
            {
                restaurarVentanaToolStripMenuItem.Enabled = true;
            }
            else
            {
                restaurarVentanaToolStripMenuItem.Enabled = false;
            }
        }

        private void cancText_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (ultextoUso)
            {
                desText.Visible = true;
            }
        }

        private void desText_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = ultexto;
        }

        private void historialDeProcesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historial historialw = new historial(prgsList);
            historialw.Show();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restaurarVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(450, 356);
            restaurarVentanaToolStripMenuItem.Enabled = false;
        }

        private void siempreVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!siempreVisibleToolStripMenuItem.Checked)
            {
                this.TopMost = true;
                siempreVisibleToolStripMenuItem.Checked = true;
            }
            else
            {
                this.TopMost = false;
                siempreVisibleToolStripMenuItem.Checked = false;
            }
        }

        private void activarDepuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SC.debug)
            {
                SC.debug = true;
                activarDepuraciónToolStripMenuItem.Checked = true;
            }
            else
            {
                SC.debug = false;
                activarDepuraciónToolStripMenuItem.Checked = false;
            }
        }
    }
}
