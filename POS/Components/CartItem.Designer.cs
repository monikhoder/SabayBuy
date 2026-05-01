namespace POS.Components
{
    partial class CartItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ktTheme1 = new KimTools.WinForms.KtTheme(this.components);
            this.bg_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Qty_txt_panel = new System.Windows.Forms.Panel();
            this.qty_txt = new KimTools.WinForms.KtTextBox();
            this.qtylbl = new KimTools.WinForms.KtLabel();
            this.price_lbl = new KimTools.WinForms.KtLabel();
            this.varient_lbl = new KimTools.WinForms.KtLabel();
            this.product_namelbl = new KimTools.WinForms.KtLabel();
            this.product_Url = new System.Windows.Forms.PictureBox();
            this.ktDivider1 = new KimTools.WinForms.KtDivider();
            this.Delete_btn = new KimTools.WinForms.KtButton();
            this.bg_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Qty_txt_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.product_Url)).BeginInit();
            this.SuspendLayout();
            // 
            // ktTheme1
            // 
            this.ktTheme1.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.ktTheme1.AccentContent = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ktTheme1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ktTheme1.BaseContent = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ktTheme1.Error = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ktTheme1.ErrorContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.ktTheme1.Info = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ktTheme1.InfoContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.ktTheme1.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ktTheme1.PrimaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ktTheme1.Secondary = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ktTheme1.SecondaryContent = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ktTheme1.Success = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(179)))), ((int)(((byte)(113)))));
            this.ktTheme1.SuccessContent = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.ktTheme1.Warning = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ktTheme1.WarningContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            // 
            // bg_panel
            // 
            this.bg_panel.BackColor = System.Drawing.Color.Transparent;
            this.bg_panel.Controls.Add(this.panel1);
            this.bg_panel.Controls.Add(this.varient_lbl);
            this.bg_panel.Controls.Add(this.product_namelbl);
            this.bg_panel.Controls.Add(this.product_Url);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bg_panel.Location = new System.Drawing.Point(5, 5);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.Size = new System.Drawing.Size(431, 111);
            this.bg_panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Qty_txt_panel);
            this.panel1.Controls.Add(this.price_lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(108, 62);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(323, 49);
            this.panel1.TabIndex = 3;
            // 
            // Qty_txt_panel
            // 
            this.Qty_txt_panel.Controls.Add(this.Delete_btn);
            this.Qty_txt_panel.Controls.Add(this.qty_txt);
            this.Qty_txt_panel.Controls.Add(this.qtylbl);
            this.Qty_txt_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Qty_txt_panel.Location = new System.Drawing.Point(1, 1);
            this.Qty_txt_panel.Name = "Qty_txt_panel";
            this.Qty_txt_panel.Padding = new System.Windows.Forms.Padding(5, 5, 6, 5);
            this.Qty_txt_panel.Size = new System.Drawing.Size(230, 47);
            this.Qty_txt_panel.TabIndex = 5;
            // 
            // qty_txt
            // 
            this.qty_txt.AcceptsReturn = false;
            this.qty_txt.AcceptsTab = false;
            this.qty_txt.AnimationSpeed = 200;
            this.qty_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.qty_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.qty_txt.AutoSizeHeight = true;
            this.qty_txt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.qty_txt.Bg = new KimTools.WinForms.KtColor(System.Drawing.Color.White, null, 100);
            this.qty_txt.Border = new KimTools.WinForms.KtColor(System.Drawing.Color.Transparent, null, 100);
            this.qty_txt.BorderActive = new KimTools.WinForms.KtColor(System.Drawing.Color.Transparent, null, 100);
            this.qty_txt.Content = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.qty_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.qty_txt.CustomIconLeft = null;
            this.qty_txt.CustomIconRight = null;
            this.qty_txt.DefaultFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qty_txt.Dock = System.Windows.Forms.DockStyle.Left;
            this.qty_txt.ForeColor = System.Drawing.Color.Empty;
            this.qty_txt.HideSelection = true;
            this.qty_txt.Lines = new string[] {
        "1"};
            this.qty_txt.Location = new System.Drawing.Point(57, 5);
            this.qty_txt.MaxLength = 32767;
            this.qty_txt.MinimumSize = new System.Drawing.Size(1, 1);
            this.qty_txt.Modified = false;
            this.qty_txt.Name = "qty_txt";
            this.qty_txt.Padding = new System.Windows.Forms.Padding(2);
            this.qty_txt.Password = false;
            this.qty_txt.PasswordChar = '\0';
            this.qty_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.qty_txt.SelectedText = "";
            this.qty_txt.SelectionLength = 0;
            this.qty_txt.SelectionStart = 0;
            this.qty_txt.ShortcutsEnabled = true;
            this.qty_txt.Size = new System.Drawing.Size(60, 37);
            this.qty_txt.Style = KimTools.WinForms.KtTextBox.KtTextBoxStyle.Tailwind;
            this.qty_txt.TabIndex = 1;
            this.qty_txt.TextMarginBottom = 0;
            this.qty_txt.TextPlaceholder = "";
            // 
            // qtylbl
            // 
            this.qtylbl.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.qtylbl.Auto = false;
            this.qtylbl.Background = KimTools.WinForms.KtColor.Empty;
            this.qtylbl.Color = KimTools.WinForms.KtColor.SECONDARY;
            this.qtylbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.qtylbl.Location = new System.Drawing.Point(5, 5);
            this.qtylbl.Name = "qtylbl";
            this.qtylbl.Size = new System.Drawing.Size(52, 37);
            this.qtylbl.TabIndex = 0;
            this.qtylbl.Text = "QTY :";
            // 
            // price_lbl
            // 
            this.price_lbl.Align = System.Drawing.ContentAlignment.MiddleCenter;
            this.price_lbl.Auto = false;
            this.price_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.price_lbl.Color = KimTools.WinForms.KtColor.PRIMARY;
            this.price_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.price_lbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_lbl.Location = new System.Drawing.Point(231, 1);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(91, 47);
            this.price_lbl.TabIndex = 3;
            this.price_lbl.Text = "$ 120.50";
            // 
            // varient_lbl
            // 
            this.varient_lbl.Align = System.Drawing.ContentAlignment.TopLeft;
            this.varient_lbl.Auto = false;
            this.varient_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.varient_lbl.Color = KimTools.WinForms.KtColor.SECONDARY;
            this.varient_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.varient_lbl.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varient_lbl.Location = new System.Drawing.Point(108, 32);
            this.varient_lbl.Name = "varient_lbl";
            this.varient_lbl.Size = new System.Drawing.Size(323, 30);
            this.varient_lbl.TabIndex = 2;
            this.varient_lbl.Text = "{Varient}";
            // 
            // product_namelbl
            // 
            this.product_namelbl.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.product_namelbl.Auto = false;
            this.product_namelbl.Background = KimTools.WinForms.KtColor.Empty;
            this.product_namelbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.product_namelbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.product_namelbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_namelbl.Location = new System.Drawing.Point(108, 0);
            this.product_namelbl.Name = "product_namelbl";
            this.product_namelbl.Size = new System.Drawing.Size(323, 32);
            this.product_namelbl.TabIndex = 1;
            this.product_namelbl.Text = "{Product Name}";
            // 
            // product_Url
            // 
            this.product_Url.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.product_Url.Dock = System.Windows.Forms.DockStyle.Left;
            this.product_Url.Image = global::POS.Properties.Resources.macbook;
            this.product_Url.Location = new System.Drawing.Point(0, 0);
            this.product_Url.Name = "product_Url";
            this.product_Url.Padding = new System.Windows.Forms.Padding(1);
            this.product_Url.Size = new System.Drawing.Size(108, 111);
            this.product_Url.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.product_Url.TabIndex = 0;
            this.product_Url.TabStop = false;
            this.product_Url.Click += new System.EventHandler(this.product_Url_Click);
            // 
            // ktDivider1
            // 
            this.ktDivider1.BackColor = System.Drawing.Color.Transparent;
            this.ktDivider1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ktDivider1.DashCap = KimTools.WinForms.KtDivider.CapStyles.Round;
            this.ktDivider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ktDivider1.LineColor = KimTools.WinForms.KtColor.SECONDARY;
            this.ktDivider1.LineStyle = KimTools.WinForms.KtDivider.LineStyles.Solid;
            this.ktDivider1.LineThickness = 2F;
            this.ktDivider1.Location = new System.Drawing.Point(5, 106);
            this.ktDivider1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ktDivider1.Name = "ktDivider1";
            this.ktDivider1.Orientation = KimTools.WinForms.KtDivider.LineOrientation.Horizontal;
            this.ktDivider1.Size = new System.Drawing.Size(431, 17);
            this.ktDivider1.TabIndex = 1;
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.Transparent;
            this.Delete_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.Delete_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Delete_btn.BorderWidth = 2F;
            this.Delete_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.Delete_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delete_btn.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, 100);
            this.Delete_btn.Icon = "";
            this.Delete_btn.IconColor = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, 100);
            this.Delete_btn.IconSize = 16;
            this.Delete_btn.IconStroke = 2.5D;
            this.Delete_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Delete_btn.Location = new System.Drawing.Point(123, 5);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(101, 37);
            this.Delete_btn.TabIndex = 2;
            this.Delete_btn.Text = "Remove";
            this.Delete_btn.UseVisualStyleBackColor = false;
            // 
            // CartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ktDivider1);
            this.Controls.Add(this.bg_panel);
            this.Name = "CartItem";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(441, 128);
            this.bg_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Qty_txt_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.product_Url)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KimTools.WinForms.KtTheme ktTheme1;
        private System.Windows.Forms.Panel bg_panel;
        private System.Windows.Forms.PictureBox product_Url;
        private KimTools.WinForms.KtDivider ktDivider1;
        private System.Windows.Forms.Panel panel1;
        private KimTools.WinForms.KtLabel varient_lbl;
        private KimTools.WinForms.KtLabel product_namelbl;
        private KimTools.WinForms.KtLabel price_lbl;
        private System.Windows.Forms.Panel Qty_txt_panel;
        private KimTools.WinForms.KtTextBox qty_txt;
        private KimTools.WinForms.KtLabel qtylbl;
        private KimTools.WinForms.KtButton Delete_btn;
    }
}
