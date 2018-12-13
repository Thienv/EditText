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
    public partial class LoginForm : Form
    {
        private string UserVld;
        private string PasswordVld;
        public LoginForm()
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
            int flat = 0;
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
                        this.Hide();
                        RichTextBoxForm f2 = new RichTextBoxForm();
                        f2.ShowDialog();
                        flat = 1;
                        
                    }

                }
            }
            catch
            {
                MessageBox.Show("Login Error!");
            }
            if(flat == 0)
            {
                MessageBox.Show("Login Failed!");
            }
            
                
            
                //show default login error message
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm f3 = new RegisterForm();
            f3.ShowDialog();            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            // The control will allow no more than 14 characters.  
            textBox2.MaxLength = 14;
        }
        

    }
}
