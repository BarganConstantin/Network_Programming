using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class Form1 : Form
    {
        private Client client;

        public Form1()
        {
            InitializeComponent();
            Text = Microsoft.VisualBasic.Interaction.InputBox("Enter your username:", "Username", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.sendToServer(this.textBox2.Text);
            textBox2.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                client.sendToServer(this.textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string ip = "127.0.0.1";
            const int port = 3000;

            client = new Client(ip, port, this);

            client.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }
    }
}
