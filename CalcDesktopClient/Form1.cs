using System;
using System.Net.Http;
using System.Windows.Forms;


namespace CalcDesktopClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HttpClient httpC;
        string fNum;
        string sNum;
        string op;
        string url = "http://localhost:8080/";
        private void Form1_Load(object sender, EventArgs e)
        {
            httpC = new HttpClient();
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

        private async void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                sNum = textBox1.Text;
                try
                {
                    textBox1.Text = await httpC.GetStringAsync($"{url}?num1={fNum}&num2={sNum}&opr={op}");
                }
                catch(HttpRequestException)
                {
                    textBox1.Text = "server not respond";
                }
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
