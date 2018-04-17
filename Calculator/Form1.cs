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

      //  public static string Number { get => number; set => number = value; }

        private void translate_Click(object sender, EventArgs e)
        {
            string Number = textBox1.Text;
            string SS1 = listBox1.Text;
            string SS2 = listBox2.Text;
            string res = Calculator.Result(Number, SS1, SS2);
            result.Text = res;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || listBox1.Text == "" || listBox2.Text == "" )
            {
                translate.Enabled = false;
            }
            else
            {
                translate.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || listBox1.Text == "" || listBox2.Text == "")
            {
                translate.Enabled = false;
            }
            else
            {
                translate.Enabled = true;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || listBox1.Text == "" || listBox2.Text == "")
            {
                translate.Enabled = false;
            }
            else
            {
                translate.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 'A' && ch != 'B' && ch != 'C' && ch != 'D' && ch != 'E' && ch != 'F' && ch != 'a' && ch != 'b' && ch != 'c' && ch != 'd' && ch != 'e' && ch != 'f') //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }
    }
}
