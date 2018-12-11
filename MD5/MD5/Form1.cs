using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace MD5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Login login = new Login("admin", "1234");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox2.Text = "";
            // The password character is an asterisk.  
           
            string user = textBox1.Text;
            string pass = textBox2.Text;
            //check if eligible to be logged in
            if (login.IsLoggedIn(user, pass))
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
                
            }
            else
            {
                //show default login error message
                MessageBox.Show("Login Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.  
            textBox2.MaxLength = 14;
        }
        

    }
}
