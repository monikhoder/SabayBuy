using KimTools.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmLogin : KtWindow
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == null || txtPassword.Text == "" || txtPassword.Text == null)
            {
                if(txtEmail.Text == "" || txtPassword.Text == null)
                {
                    lbl_email.Visible = true;
                }
                if (txtPassword.Text == "" || txtPassword.Text == null)
                {
                    lbl_password.Visible = true;
                }
            }
            else
            {
                
            }


        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtEmail_TextChange(object sender, EventArgs e)
        {
            lbl_email.Visible = false;

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_TextChange(object sender, EventArgs e)
        {
            lbl_password.Visible = false;

        }
    }
}
