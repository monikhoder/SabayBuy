namespace POS
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.top_panel = new System.Windows.Forms.Panel();
            this.icon = new KimTools.WinForms.KtPictureBox();
            this.body_panel = new System.Windows.Forms.Panel();
            this.btn_login = new KimTools.WinForms.KtButton();
            this.Exit_btn = new KimTools.WinForms.KtButton();
            this.lbl_password = new KimTools.WinForms.KtLabel();
            this.lbl_email = new KimTools.WinForms.KtLabel();
            this.txtPassword = new KimTools.WinForms.KtTextBox();
            this.txtEmail = new KimTools.WinForms.KtTextBox();
            this.ktTheme = new KimTools.WinForms.KtTheme(this.components);
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.body_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.icon);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(430, 221);
            this.top_panel.TabIndex = 0;
            // 
            // icon
            // 
            this.icon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icon.BackColor = System.Drawing.Color.Transparent;
            this.icon.Image = global::POS.Properties.Resources.people;
            this.icon.ImageBrush = ((KimTools.WinForms.KtBrushNone)(KimTools.WinForms.KtBrush.None));
            this.icon.Location = new System.Drawing.Point(144, 51);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(117, 117);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // body_panel
            // 
            this.body_panel.Controls.Add(this.btn_login);
            this.body_panel.Controls.Add(this.Exit_btn);
            this.body_panel.Controls.Add(this.lbl_password);
            this.body_panel.Controls.Add(this.lbl_email);
            this.body_panel.Controls.Add(this.txtPassword);
            this.body_panel.Controls.Add(this.txtEmail);
            this.body_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_panel.Location = new System.Drawing.Point(0, 221);
            this.body_panel.Name = "body_panel";
            this.body_panel.Size = new System.Drawing.Size(430, 426);
            this.body_panel.TabIndex = 1;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_login.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.BlueViolet);
            this.btn_login.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btn_login.BorderWidth = 2F;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.White, null, 100);
            this.btn_login.Icon = "";
            this.btn_login.IconColor = KimTools.WinForms.KtColor.Empty;
            this.btn_login.IconSize = 16;
            this.btn_login.IconStroke = 2.5D;
            this.btn_login.Location = new System.Drawing.Point(259, 243);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 48);
            this.btn_login.TabIndex = 7;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.Exit_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.BlueViolet);
            this.Exit_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Exit_btn.BorderWidth = 2F;
            this.Exit_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Exit_btn.Foreground = KimTools.WinForms.KtColor.Empty;
            this.Exit_btn.Icon = "";
            this.Exit_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.Exit_btn.IconSize = 16;
            this.Exit_btn.IconStroke = 2.5D;
            this.Exit_btn.Location = new System.Drawing.Point(48, 243);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(120, 48);
            this.Exit_btn.TabIndex = 6;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = false;
            this.Exit_btn.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_password
            // 
            this.lbl_password.Align = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_password.Auto = false;
            this.lbl_password.Background = KimTools.WinForms.KtColor.Empty;
            this.lbl_password.Color = KimTools.WinForms.KtColor.ERROR;
            this.lbl_password.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(48, 196);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(180, 23);
            this.lbl_password.TabIndex = 5;
            this.lbl_password.Text = "Password can not empty";
            this.lbl_password.Visible = false;
            // 
            // lbl_email
            // 
            this.lbl_email.Align = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_email.Auto = false;
            this.lbl_email.Background = KimTools.WinForms.KtColor.Empty;
            this.lbl_email.Color = KimTools.WinForms.KtColor.ERROR;
            this.lbl_email.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(48, 115);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(180, 23);
            this.lbl_email.TabIndex = 4;
            this.lbl_email.Text = "Email can not empty";
            this.lbl_email.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = false;
            this.txtPassword.AcceptsTab = false;
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.AnimationSpeed = 200;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.AutoSizeHeight = true;
            this.txtPassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPassword.Bg = KimTools.WinForms.KtColor.BASE_2;
            this.txtPassword.Border = KimTools.WinForms.KtColor.SECONDARY;
            this.txtPassword.BorderActive = KimTools.WinForms.KtColor.ACCENT;
            this.txtPassword.Content = new KimTools.WinForms.KtColor("$PrimaryContent", null, 100);
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.CustomIconLeft = null;
            this.txtPassword.CustomIconRight = null;
            this.txtPassword.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Empty;
            this.txtPassword.HideSelection = true;
            this.txtPassword.IconLeft = "tabler.outline.key";
            this.txtPassword.Lines = new string[] {
        "Johnsmith@123"};
            this.txtPassword.Location = new System.Drawing.Point(48, 144);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPassword.Modified = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Password = true;
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 13;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(331, 49);
            this.txtPassword.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextMarginBottom = 0;
            this.txtPassword.TextPlaceholder = "Password";
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.TextChange += new System.EventHandler(this.txtPassword_TextChange);
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = false;
            this.txtEmail.AcceptsTab = false;
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.AnimationSpeed = 200;
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEmail.AutoSizeHeight = true;
            this.txtEmail.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEmail.Bg = KimTools.WinForms.KtColor.BASE_2;
            this.txtEmail.Border = KimTools.WinForms.KtColor.SECONDARY;
            this.txtEmail.BorderActive = KimTools.WinForms.KtColor.ACCENT;
            this.txtEmail.Content = new KimTools.WinForms.KtColor("$PrimaryContent", null, 100);
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.CustomIconLeft = null;
            this.txtEmail.CustomIconRight = null;
            this.txtEmail.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Empty;
            this.txtEmail.HideSelection = true;
            this.txtEmail.IconLeft = "tabler.outline.user";
            this.txtEmail.Lines = new string[] {
        "John.smith@sabbay-buy.com"};
            this.txtEmail.Location = new System.Drawing.Point(48, 59);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtEmail.Modified = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Password = false;
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 25;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(331, 49);
            this.txtEmail.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            this.txtEmail.TabIndex = 0;
            this.txtEmail.TextMarginBottom = 0;
            this.txtEmail.TextPlaceholder = "Email";
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.TextChange += new System.EventHandler(this.txtEmail_TextChange);
            // 
            // ktTheme
            // 
            this.ktTheme.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ktTheme.AccentContent = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ktTheme.Base = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ktTheme.BaseContent = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ktTheme.Error = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ktTheme.ErrorContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.ktTheme.Info = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ktTheme.InfoContent = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ktTheme.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.ktTheme.PrimaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ktTheme.Secondary = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ktTheme.SecondaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ktTheme.Success = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(179)))), ((int)(((byte)(113)))));
            this.ktTheme.SuccessContent = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.ktTheme.Warning = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ktTheme.WarningContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))));
            this.ClientSize = new System.Drawing.Size(430, 647);
            this.Controls.Add(this.body_panel);
            this.Controls.Add(this.top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.top_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.body_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private KimTools.WinForms.KtPictureBox icon;
        private System.Windows.Forms.Panel body_panel;
        private KimTools.WinForms.KtTextBox txtEmail;
        private KimTools.WinForms.KtTextBox txtPassword;
        private KimTools.WinForms.KtLabel lbl_email;
        private KimTools.WinForms.KtLabel lbl_password;
        private KimTools.WinForms.KtTheme ktTheme;
        private KimTools.WinForms.KtButton Exit_btn;
        private KimTools.WinForms.KtButton btn_login;
    }
}

