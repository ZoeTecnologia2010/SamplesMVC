using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Samples.Model;
using Samples.Entities;

namespace Samples.View
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((textUser.Text != "") && (textPassword.Text != ""))
            {
                UserEnt obj = new UserEnt();
                obj.Name = textUser.Text;
                obj.Password = textPassword.Text;

                obj = new UserModel().Login(obj);

                if (obj.Name == null)
                {
                    MessageBox.Show("User or password invalid!");
                    textUser.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("==>> Wellcome " + obj.Name + " <<==");
                    btnCancel_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Input user and password!");
                textUser.Focus();
            }
        }
    }
}
