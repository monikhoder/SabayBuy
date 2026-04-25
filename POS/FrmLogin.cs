using KimTools.WinForms;
using POS.ApiServices;
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
        private readonly POSAccountService accountService = new POSAccountService();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lbl_email.Visible = string.IsNullOrWhiteSpace(email);
                lbl_password.Visible = string.IsNullOrWhiteSpace(password);
                return;
            }

            btn_login.Enabled = false;
            btn_login.Text = "Logging in...";

            var result = await accountService.LoginAsync(email, password);

            btn_login.Enabled = true;
            btn_login.Text = "Login";

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "POS Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
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
