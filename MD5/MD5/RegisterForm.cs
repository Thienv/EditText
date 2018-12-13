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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static string MD5Hash(string textBox2)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(textBox2));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\MyTest.txt";
            if (!this.ValidatePassword())
            {
                MessageBox.Show("Password not same! Please enter");
            }
            else
            {
                try
                {
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, txtUserName.Text + "\t" + Login.ConvertMD5Hash(txtRgtPassword.Text) + Environment.NewLine);
                        
                    }
                    File.AppendAllText(path, txtUserName.Text + "\t" + Login.ConvertMD5Hash(txtRgtPassword.Text) + Environment.NewLine);
                    MessageBox.Show("register successfull!");
                    this.Hide();
                    RichTextBoxForm rbf = new RichTextBoxForm();
                    rbf.Show();
                }
                catch
                {
                    MessageBox.Show("not success!");
                }
                
            }
        }

        private bool ValidatePassword()
        {
            if(txtRgtPassword.Text == txtRgtRePassword.Text)
            {
                return true;
            }
            return false;
        }
        
    }
}
