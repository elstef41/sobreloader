using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sobreloader
{
    public partial class historial : Form
    {
        List<string> pgrsListf1;
        public historial(List<string> prgsList)
        {
            InitializeComponent();
            pgrsListf1 = prgsList;
            var prgSel = listBox1.SelectedItem;
            foreach (var item in pgrsListf1)
            {
                listBox1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in pgrsListf1)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {        
            var prgSel = listBox1.GetItemText(listBox1.SelectedItem);
            if (prgSel == "")
            {
                button2.Enabled = false;
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(prgSel);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

    }
}
