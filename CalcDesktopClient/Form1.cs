using System;
using System.Net.Http;
using System.Windows.Forms;
using CalcDesktopClient.ServerCalculator;


namespace CalcDesktopClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _sCalc = new ServerCalc();
        }
        private ServerCalc _sCalc;
        string fNum;
        string sNum;
        string op;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text += ((Button)sender).Text;
            }
            catch (InvalidCastException)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                fNum = textBox1.Text;
                op = ((Button)sender).Text;
                if (op == "+") { op = "plus"; }
                textBox1.Text = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            sNum = textBox1.Text;
            try
            {
                textBox1.Text = _sCalc.Calculate(fNum, sNum, op);
            }
            catch(HttpRequestException)
            {
                textBox1.Text = "server not respond";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            fNum = sNum = op = null;
            textBox1.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" )
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }
    }
}
