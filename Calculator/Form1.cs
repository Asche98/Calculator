using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void translate_Click(object sender, EventArgs e)
        {
            string Number = textBox1.Text;
            string SS1 = listBox1.Text;
            string SS2 = listBox2.Text;
            string res = Calculator.Result(Number, SS1, SS2);
            result.Text = res;
        }
    }
}
