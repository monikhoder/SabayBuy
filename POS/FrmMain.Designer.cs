namespace POS
{
    partial class FrmMain
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
            this.MainTheme = new KimTools.WinForms.KtTheme(this.components);
            this.bg_panel = new System.Windows.Forms.Panel();
            this.body_panel = new System.Windows.Forms.Panel();
            this.order_summary_panel = new KimTools.WinForms.KtPanel();
            this.header_panel = new System.Windows.Forms.Panel();
            this.datetime_panel = new System.Windows.Forms.Panel();
            this.datetime_lbl = new KimTools.WinForms.KtLabel();
            this.profile_panel = new System.Windows.Forms.Panel();
            this.profile_picture = new KimTools.WinForms.KtPictureBox();
            this.username_lbl = new KimTools.WinForms.KtLabel();
            this.exit_panel = new System.Windows.Forms.Panel();
            this.exit_btn = new KimTools.WinForms.KtButton();
            this.search_panel = new System.Windows.Forms.Panel();
            this.txt_search = new KimTools.WinForms.KtTextBox();
            this.logo_panel = new System.Windows.Forms.Panel();
            this.logo_header = new KimTools.WinForms.KtPictureBox();
            this.bg_panel.SuspendLayout();
            this.body_panel.SuspendLayout();
            this.header_panel.SuspendLayout();
            this.datetime_panel.SuspendLayout();
            this.profile_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profile_picture)).BeginInit();
            this.exit_panel.SuspendLayout();
            this.search_panel.SuspendLayout();
            this.logo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_header)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTheme
            // 
            this.MainTheme.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.MainTheme.AccentContent = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainTheme.Base = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainTheme.BaseContent = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainTheme.Error = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainTheme.ErrorContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.MainTheme.Info = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.MainTheme.InfoContent = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.MainTheme.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.MainTheme.PrimaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainTheme.Secondary = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MainTheme.SecondaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.MainTheme.Success = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(179)))), ((int)(((byte)(113)))));
            this.MainTheme.SuccessContent = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.MainTheme.Warning = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.MainTheme.WarningContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            // 
            // bg_panel
            // 
            this.bg_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bg_panel.Controls.Add(this.body_panel);
            this.bg_panel.Controls.Add(this.header_panel);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg_panel.Location = new System.Drawing.Point(2, 2);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.Size = new System.Drawing.Size(1256, 669);
            this.bg_panel.TabIndex = 0;
            // 
            // body_panel
            // 
            this.body_panel.Controls.Add(this.order_summary_panel);
            this.body_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_panel.Location = new System.Drawing.Point(0, 63);
            this.body_panel.Name = "body_panel";
            this.body_panel.Padding = new System.Windows.Forms.Padding(3, 3, 8, 5);
            this.body_panel.Size = new System.Drawing.Size(1256, 606);
            this.body_panel.TabIndex = 1;
            // 
            // order_summary_panel
            // 
            this.order_summary_panel.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            this.order_summary_panel.Border = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.order_summary_panel.BorderRadius = 24F;
            this.order_summary_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.order_summary_panel.BorderWidth = 0F;
            this.order_summary_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.order_summary_panel.Foreground = KimTools.WinForms.KtColor.Empty;
            this.order_summary_panel.Location = new System.Drawing.Point(783, 3);
            this.order_summary_panel.Name = "order_summary_panel";
            this.order_summary_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.order_summary_panel.Size = new System.Drawing.Size(465, 598);
            this.order_summary_panel.TabIndex = 0;
            // 
            // header_panel
            // 
            this.header_panel.Controls.Add(this.datetime_panel);
            this.header_panel.Controls.Add(this.profile_panel);
            this.header_panel.Controls.Add(this.exit_panel);
            this.header_panel.Controls.Add(this.search_panel);
            this.header_panel.Controls.Add(this.logo_panel);
            this.header_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_panel.Location = new System.Drawing.Point(0, 0);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(1256, 63);
            this.header_panel.TabIndex = 0;
            // 
            // datetime_panel
            // 
            this.datetime_panel.Controls.Add(this.datetime_lbl);
            this.datetime_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.datetime_panel.Location = new System.Drawing.Point(836, 0);
            this.datetime_panel.Name = "datetime_panel";
            this.datetime_panel.Size = new System.Drawing.Size(182, 63);
            this.datetime_panel.TabIndex = 4;
            // 
            // datetime_lbl
            // 
            this.datetime_lbl.Align = System.Drawing.ContentAlignment.MiddleCenter;
            this.datetime_lbl.Auto = false;
            this.datetime_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.datetime_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.datetime_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetime_lbl.Location = new System.Drawing.Point(0, 0);
            this.datetime_lbl.Name = "datetime_lbl";
            this.datetime_lbl.Size = new System.Drawing.Size(182, 63);
            this.datetime_lbl.TabIndex = 0;
            this.datetime_lbl.Text = "24 - Apr - 2026 12:21 PM";
            // 
            // profile_panel
            // 
            this.profile_panel.Controls.Add(this.profile_picture);
            this.profile_panel.Controls.Add(this.username_lbl);
            this.profile_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.profile_panel.Location = new System.Drawing.Point(1018, 0);
            this.profile_panel.Margin = new System.Windows.Forms.Padding(6);
            this.profile_panel.Name = "profile_panel";
            this.profile_panel.Padding = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.profile_panel.Size = new System.Drawing.Size(151, 63);
            this.profile_panel.TabIndex = 3;
            // 
            // profile_picture
            // 
            this.profile_picture.BackColor = System.Drawing.Color.Transparent;
            this.profile_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profile_picture.Image = global::POS.Properties.Resources.people;
            this.profile_picture.ImageBrush = ((KimTools.WinForms.KtBrushNone)(KimTools.WinForms.KtBrush.None));
            this.profile_picture.Location = new System.Drawing.Point(3, 8);
            this.profile_picture.Margin = new System.Windows.Forms.Padding(6);
            this.profile_picture.Name = "profile_picture";
            this.profile_picture.Padding = new System.Windows.Forms.Padding(3);
            this.profile_picture.Size = new System.Drawing.Size(37, 47);
            this.profile_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profile_picture.TabIndex = 1;
            this.profile_picture.TabStop = false;
            // 
            // username_lbl
            // 
            this.username_lbl.Align = System.Drawing.ContentAlignment.MiddleCenter;
            this.username_lbl.Auto = false;
            this.username_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.username_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.username_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.username_lbl.Location = new System.Drawing.Point(40, 8);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(108, 47);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "Moni";
            // 
            // exit_panel
            // 
            this.exit_panel.Controls.Add(this.exit_btn);
            this.exit_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.exit_panel.Location = new System.Drawing.Point(1169, 0);
            this.exit_panel.Name = "exit_panel";
            this.exit_panel.Padding = new System.Windows.Forms.Padding(6, 6, 25, 6);
            this.exit_panel.Size = new System.Drawing.Size(87, 63);
            this.exit_panel.TabIndex = 2;
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_btn.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.ERROR);
            this.exit_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.exit_btn.BorderWidth = 2F;
            this.exit_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.exit_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exit_btn.Foreground = KimTools.WinForms.KtColor.Empty;
            this.exit_btn.Icon = "tabler.outline.logout";
            this.exit_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.exit_btn.IconSize = 16;
            this.exit_btn.IconStroke = 2.5D;
            this.exit_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exit_btn.Location = new System.Drawing.Point(6, 6);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(53, 51);
            this.exit_btn.TabIndex = 0;
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.txt_search);
            this.search_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.search_panel.Location = new System.Drawing.Point(124, 0);
            this.search_panel.Name = "search_panel";
            this.search_panel.Padding = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.search_panel.Size = new System.Drawing.Size(389, 63);
            this.search_panel.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.AcceptsReturn = false;
            this.txt_search.AcceptsTab = false;
            this.txt_search.AnimationSpeed = 200;
            this.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_search.AutoSizeHeight = true;
            this.txt_search.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txt_search.Bg = KimTools.WinForms.KtColor.BASE_2;
            this.txt_search.Border = new KimTools.WinForms.KtColor("$Content", null, 25);
            this.txt_search.BorderActive = KimTools.WinForms.KtColor.PRIMARY;
            this.txt_search.BorderRadius = -2;
            this.txt_search.Content = new KimTools.WinForms.KtColor("$SecondaryContent", null, 100);
            this.txt_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_search.CustomIconLeft = null;
            this.txt_search.CustomIconRight = null;
            this.txt_search.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_search.ForeColor = System.Drawing.Color.Empty;
            this.txt_search.HideSelection = true;
            this.txt_search.IconLeft = "tabler.outline.search";
            this.txt_search.Lines = new string[0];
            this.txt_search.Location = new System.Drawing.Point(2, 6);
            this.txt_search.MaxLength = 32767;
            this.txt_search.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_search.Modified = false;
            this.txt_search.Name = "txt_search";
            this.txt_search.Password = false;
            this.txt_search.PasswordChar = '\0';
            this.txt_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_search.SelectedText = "";
            this.txt_search.SelectionLength = 0;
            this.txt_search.SelectionStart = 0;
            this.txt_search.ShortcutsEnabled = true;
            this.txt_search.Size = new System.Drawing.Size(385, 51);
            this.txt_search.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            this.txt_search.TabIndex = 1;
            this.txt_search.TextMarginBottom = 0;
            this.txt_search.TextPlaceholder = "Type to search  (product name , brand , SKU..)";
            // 
            // logo_panel
            // 
            this.logo_panel.Controls.Add(this.logo_header);
            this.logo_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.logo_panel.Location = new System.Drawing.Point(0, 0);
            this.logo_panel.Name = "logo_panel";
            this.logo_panel.Padding = new System.Windows.Forms.Padding(2);
            this.logo_panel.Size = new System.Drawing.Size(124, 63);
            this.logo_panel.TabIndex = 0;
            // 
            // logo_header
            // 
            this.Set_Drag(this.logo_header, true);
            this.logo_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.logo_header.BackColor = System.Drawing.Color.Transparent;
            this.logo_header.Image = global::POS.Properties.Resources.sabay_buy_logo_header1;
            this.logo_header.ImageBrush = ((KimTools.WinForms.KtBrushNone)(KimTools.WinForms.KtBrush.None));
            this.logo_header.Location = new System.Drawing.Point(0, 0);
            this.logo_header.Name = "logo_header";
            this.logo_header.Size = new System.Drawing.Size(124, 63);
            this.logo_header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo_header.TabIndex = 0;
            this.logo_header.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.bg_panel);
            this.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), null, 100);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sabbay POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bg_panel.ResumeLayout(false);
            this.body_panel.ResumeLayout(false);
            this.header_panel.ResumeLayout(false);
            this.datetime_panel.ResumeLayout(false);
            this.profile_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profile_picture)).EndInit();
            this.exit_panel.ResumeLayout(false);
            this.search_panel.ResumeLayout(false);
            this.logo_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo_header)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected KimTools.WinForms.KtTheme MainTheme;
        private System.Windows.Forms.Panel bg_panel;
        private System.Windows.Forms.Panel body_panel;
        private KimTools.WinForms.KtPanel order_summary_panel;
        private System.Windows.Forms.Panel header_panel;
        private KimTools.WinForms.KtTextBox txt_search;
        private System.Windows.Forms.Panel logo_panel;
        private KimTools.WinForms.KtPictureBox logo_header;
        private System.Windows.Forms.Panel search_panel;
        private System.Windows.Forms.Panel exit_panel;
        private KimTools.WinForms.KtButton exit_btn;
        private System.Windows.Forms.Panel datetime_panel;
        private KimTools.WinForms.KtLabel datetime_lbl;
        private System.Windows.Forms.Panel profile_panel;
        private KimTools.WinForms.KtPictureBox profile_picture;
        private KimTools.WinForms.KtLabel username_lbl;
    }
}