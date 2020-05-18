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
    public partial class FormOfSetRadius : Form
    {
        public int TextFromFormOfSetRadius;

        public FormOfSetRadius()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBox1.Text, out TextFromFormOfSetRadius);
            if(TextFromFormOfSetRadius == 0)
            {
                MessageBox.Show("Вы ввели неправильный радиус, поэтому радиун данной вершины приведён к default(15)");
                TextFromFormOfSetRadius = 15;
            }
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Int32.TryParse(textBox1.Text, out TextFromFormOfSetRadius);                
                if (TextFromFormOfSetRadius == 0)
                {
                    MessageBox.Show("Вы ввели неправильный радиус, поэтому радиун данной вершины приведён к default(15)");
                    TextFromFormOfSetRadius = 15;
                }
                Close();
            }
        }

        private void FormOfSetRadius_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (TextFromFormOfSetRadius == 0)
            {
                MessageBox.Show("Вы ввели неправильный радиус, поэтому радиун данной вершины приведён к default(15)");
                TextFromFormOfSetRadius = 15;
            }
            textBox1.Text = default(string);
        }
    }
}
