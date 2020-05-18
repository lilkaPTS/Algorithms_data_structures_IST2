using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qwe.Molecules
{
    public partial class FormOfSetText : Form
    {
        public string TextFromFormOfSetText;

        public FormOfSetText()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextFromFormOfSetText = textBox1.Text;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextFromFormOfSetText = textBox1.Text;
                Close();
            }
        }

        private void FormOfSetText_FormClosed(object sender, FormClosedEventArgs e)
        {
            TextFromFormOfSetText = textBox1.Text;
            textBox1.Text = default(string);
        }
    }
}
