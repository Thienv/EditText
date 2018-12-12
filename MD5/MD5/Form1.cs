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
using System.IO;

namespace MD5
{
    public partial class Form1 : Form
    {
        private string UserVld;
        private string PasswordVld;
        public Form1()
        {
            InitializeComponent();
            this.UserVld = "";
            this.PasswordVld = "";
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {


                string path = @"D:\MyTest.txt";

                IEnumerable<String> readText = File.ReadAllLines(path);
                foreach (string text in readText)
                {
                    int index = text.IndexOf("\t");
                    this.UserVld = text.Substring(0, index);
                    this.PasswordVld = text.Substring(index + 1);
                    Login login = new Login(UserVld, PasswordVld);
                    string user = textBox1.Text;
                    string pass = Login.ConvertMD5Hash(textBox2.Text);
                    //check if eligible to be logged in
                    if (login.IsLoggedIn(user, pass))
                    {

                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                        
                    }

                }
            }
            catch
            {
                MessageBox.Show("Login Error!");
            }
            
            
                
            
                //show default login error message
                
            
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
