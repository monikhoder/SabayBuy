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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MainTheme = new KimTools.WinForms.KtTheme(this.components);
            this.bg_panel = new System.Windows.Forms.Panel();
            this.body_panel = new System.Windows.Forms.Panel();
            this.body_left_panel = new System.Windows.Forms.Panel();
            this.product_panel = new System.Windows.Forms.Panel();
            this.list_product_panel = new System.Windows.Forms.Panel();
            this.product_list_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.productCard1 = new POS.Components.ProductCard();
            this.product_lbl = new KimTools.WinForms.KtLabel();
            this.categories_panel = new System.Windows.Forms.Panel();
            this.categories_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryCard1 = new POS.Components.CategoryCard();
            this.category_title_lbl = new KimTools.WinForms.KtLabel();
            this.header_panel = new System.Windows.Forms.Panel();
            this.profile_panel = new System.Windows.Forms.Panel();
            this.datetime_lbl = new KimTools.WinForms.KtLabel();
            this.username_lbl = new KimTools.WinForms.KtLabel();
            this.search_panel = new System.Windows.Forms.Panel();
            this.txt_search = new KimTools.WinForms.KtTextBox();
            this.logo_panel = new System.Windows.Forms.Panel();
            this.logo_header = new KimTools.WinForms.KtPictureBox();
            this.order_summary_panel = new KimTools.WinForms.KtPanel();
            this.orders1 = new POS.Components.orders();
            this.bg_panel.SuspendLayout();
            this.body_panel.SuspendLayout();
            this.body_left_panel.SuspendLayout();
            this.product_panel.SuspendLayout();
            this.list_product_panel.SuspendLayout();
            this.product_list_flowLayoutPanel.SuspendLayout();
            this.categories_panel.SuspendLayout();
            this.categories_flowLayoutPanel.SuspendLayout();
            this.header_panel.SuspendLayout();
            this.profile_panel.SuspendLayout();
            this.search_panel.SuspendLayout();
            this.logo_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_header)).BeginInit();
            this.order_summary_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTheme
            // 
            this.MainTheme.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.MainTheme.AccentContent = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainTheme.Base = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainTheme.BaseContent = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainTheme.Error = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainTheme.ErrorContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.MainTheme.Info = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.MainTheme.InfoContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MainTheme.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
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
            this.bg_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bg_panel.Controls.Add(this.body_panel);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg_panel.Location = new System.Drawing.Point(0, 0);
            this.bg_panel.Margin = new System.Windows.Forms.Padding(0);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.Size = new System.Drawing.Size(1262, 673);
            this.bg_panel.TabIndex = 0;
            // 
            // body_panel
            // 
            this.body_panel.Controls.Add(this.body_left_panel);
            this.body_panel.Controls.Add(this.order_summary_panel);
            this.body_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_panel.Location = new System.Drawing.Point(0, 0);
            this.body_panel.Name = "body_panel";
            this.body_panel.Size = new System.Drawing.Size(1262, 673);
            this.body_panel.TabIndex = 1;
            // 
            // body_left_panel
            // 
            this.body_left_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.body_left_panel.Controls.Add(this.product_panel);
            this.body_left_panel.Controls.Add(this.header_panel);
            this.body_left_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_left_panel.Location = new System.Drawing.Point(0, 0);
            this.body_left_panel.Name = "body_left_panel";
            this.body_left_panel.Size = new System.Drawing.Size(842, 673);
            this.body_left_panel.TabIndex = 1;
            // 
            // product_panel
            // 
            this.product_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.product_panel.Controls.Add(this.list_product_panel);
            this.product_panel.Controls.Add(this.product_lbl);
            this.product_panel.Controls.Add(this.categories_panel);
            this.product_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product_panel.Location = new System.Drawing.Point(0, 63);
            this.product_panel.Name = "product_panel";
            this.product_panel.Size = new System.Drawing.Size(842, 610);
            this.product_panel.TabIndex = 1;
            // 
            // list_product_panel
            // 
            this.list_product_panel.Controls.Add(this.product_list_flowLayoutPanel);
            this.list_product_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_product_panel.Location = new System.Drawing.Point(0, 172);
            this.list_product_panel.Name = "list_product_panel";
            this.list_product_panel.Size = new System.Drawing.Size(842, 438);
            this.list_product_panel.TabIndex = 8;
            // 
            // product_list_flowLayoutPanel
            // 
            this.product_list_flowLayoutPanel.Controls.Add(this.productCard1);
            this.product_list_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product_list_flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.product_list_flowLayoutPanel.Name = "product_list_flowLayoutPanel";
            this.product_list_flowLayoutPanel.Size = new System.Drawing.Size(842, 438);
            this.product_list_flowLayoutPanel.TabIndex = 6;
            // 
            // productCard1
            // 
            this.productCard1.BackColor = System.Drawing.Color.Transparent;
            this.productCard1.Location = new System.Drawing.Point(3, 4);
            this.productCard1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productCard1.Name = "productCard1";
            this.productCard1.Padding = new System.Windows.Forms.Padding(6);
            this.productCard1.Size = new System.Drawing.Size(208, 281);
            this.productCard1.TabIndex = 0;
            // 
            // product_lbl
            // 
            this.product_lbl.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.product_lbl.Auto = false;
            this.product_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.product_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.product_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.product_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_lbl.Location = new System.Drawing.Point(0, 136);
            this.product_lbl.Name = "product_lbl";
            this.product_lbl.Size = new System.Drawing.Size(842, 36);
            this.product_lbl.TabIndex = 7;
            this.product_lbl.Text = "Product";
            // 
            // categories_panel
            // 
            this.categories_panel.Controls.Add(this.categories_flowLayoutPanel);
            this.categories_panel.Controls.Add(this.category_title_lbl);
            this.categories_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categories_panel.Location = new System.Drawing.Point(0, 0);
            this.categories_panel.Name = "categories_panel";
            this.categories_panel.Size = new System.Drawing.Size(842, 136);
            this.categories_panel.TabIndex = 0;
            // 
            // categories_flowLayoutPanel
            // 
            this.categories_flowLayoutPanel.Controls.Add(this.categoryCard1);
            this.categories_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categories_flowLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.categories_flowLayoutPanel.Name = "categories_flowLayoutPanel";
            this.categories_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.categories_flowLayoutPanel.Size = new System.Drawing.Size(842, 106);
            this.categories_flowLayoutPanel.TabIndex = 4;
            this.categories_flowLayoutPanel.WrapContents = false;
            // 
            // categoryCard1
            // 
            this.categoryCard1.BackColor = System.Drawing.Color.Transparent;
            this.categoryCard1.Location = new System.Drawing.Point(10, 2);
            this.categoryCard1.Margin = new System.Windows.Forms.Padding(2);
            this.categoryCard1.Name = "categoryCard1";
            this.categoryCard1.Padding = new System.Windows.Forms.Padding(2);
            this.categoryCard1.Size = new System.Drawing.Size(90, 98);
            this.categoryCard1.TabIndex = 0;
            // 
            // category_title_lbl
            // 
            this.category_title_lbl.Align = System.Drawing.ContentAlignment.TopLeft;
            this.category_title_lbl.Auto = false;
            this.category_title_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.category_title_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.category_title_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.category_title_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_title_lbl.Location = new System.Drawing.Point(0, 0);
            this.category_title_lbl.Name = "category_title_lbl";
            this.category_title_lbl.Size = new System.Drawing.Size(842, 30);
            this.category_title_lbl.TabIndex = 3;
            this.category_title_lbl.Text = "Categories";
            // 
            // header_panel
            // 
            this.header_panel.BackColor = System.Drawing.Color.White;
            this.header_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.header_panel.Controls.Add(this.profile_panel);
            this.header_panel.Controls.Add(this.search_panel);
            this.header_panel.Controls.Add(this.logo_panel);
            this.header_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_panel.Location = new System.Drawing.Point(0, 0);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(842, 63);
            this.header_panel.TabIndex = 0;
            // 
            // profile_panel
            // 
            this.profile_panel.Controls.Add(this.datetime_lbl);
            this.profile_panel.Controls.Add(this.username_lbl);
            this.profile_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.profile_panel.Location = new System.Drawing.Point(655, 0);
            this.profile_panel.Margin = new System.Windows.Forms.Padding(6);
            this.profile_panel.Name = "profile_panel";
            this.profile_panel.Padding = new System.Windows.Forms.Padding(1);
            this.profile_panel.Size = new System.Drawing.Size(187, 63);
            this.profile_panel.TabIndex = 3;
            // 
            // datetime_lbl
            // 
            this.datetime_lbl.Align = System.Drawing.ContentAlignment.TopCenter;
            this.datetime_lbl.Auto = false;
            this.datetime_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.datetime_lbl.Color = KimTools.WinForms.KtColor.SECONDARY;
            this.datetime_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetime_lbl.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetime_lbl.Location = new System.Drawing.Point(1, 32);
            this.datetime_lbl.Name = "datetime_lbl";
            this.datetime_lbl.Size = new System.Drawing.Size(185, 30);
            this.datetime_lbl.TabIndex = 0;
            this.datetime_lbl.Text = "24 - Apr - 2026 12:21 PM";
            // 
            // username_lbl
            // 
            this.username_lbl.Align = System.Drawing.ContentAlignment.BottomCenter;
            this.username_lbl.Auto = false;
            this.username_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.username_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.username_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.username_lbl.Location = new System.Drawing.Point(1, 1);
            this.username_lbl.Name = "username_lbl";
            this.username_lbl.Size = new System.Drawing.Size(185, 31);
            this.username_lbl.TabIndex = 0;
            this.username_lbl.Text = "Moni";
            // 
            // search_panel
            // 
            this.search_panel.Controls.Add(this.txt_search);
            this.search_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.search_panel.Location = new System.Drawing.Point(124, 0);
            this.search_panel.Name = "search_panel";
            this.search_panel.Padding = new System.Windows.Forms.Padding(2, 12, 2, 2);
            this.search_panel.Size = new System.Drawing.Size(393, 63);
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
            this.txt_search.Border = new KimTools.WinForms.KtColor(System.Drawing.Color.Silver, null, 25);
            this.txt_search.BorderActive = new KimTools.WinForms.KtColor(System.Drawing.Color.DarkGray, null, 100);
            this.txt_search.BorderRadius = -2;
            this.txt_search.Content = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.txt_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_search.CustomIconLeft = null;
            this.txt_search.CustomIconRight = null;
            this.txt_search.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_search.ForeColor = System.Drawing.Color.Empty;
            this.txt_search.HideSelection = true;
            this.txt_search.IconLeft = "tabler.outline.search";
            this.txt_search.Lines = new string[0];
            this.txt_search.Location = new System.Drawing.Point(2, 12);
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
            this.txt_search.Size = new System.Drawing.Size(389, 49);
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
            // order_summary_panel
            // 
            this.order_summary_panel.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            this.order_summary_panel.Border = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Silver);
            this.order_summary_panel.BorderEdges.BottomLeft = false;
            this.order_summary_panel.BorderEdges.BottomRight = false;
            this.order_summary_panel.BorderEdges.TopLeft = false;
            this.order_summary_panel.BorderEdges.TopRight = false;
            this.order_summary_panel.BorderRadius = 2F;
            this.order_summary_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.order_summary_panel.BorderWidth = 2F;
            this.order_summary_panel.Controls.Add(this.orders1);
            this.order_summary_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.order_summary_panel.Foreground = KimTools.WinForms.KtColor.Empty;
            this.order_summary_panel.Location = new System.Drawing.Point(842, 0);
            this.order_summary_panel.Margin = new System.Windows.Forms.Padding(0);
            this.order_summary_panel.Name = "order_summary_panel";
            this.order_summary_panel.Padding = new System.Windows.Forms.Padding(12);
            this.order_summary_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.order_summary_panel.Size = new System.Drawing.Size(420, 673);
            this.order_summary_panel.TabIndex = 0;
            // 
            // orders1
            // 
            this.orders1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orders1.Location = new System.Drawing.Point(12, 12);
            this.orders1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.orders1.Name = "orders1";
            this.orders1.Size = new System.Drawing.Size(396, 649);
            this.orders1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.bg_panel);
            this.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), null, 100);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sabbay POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.bg_panel.ResumeLayout(false);
            this.body_panel.ResumeLayout(false);
            this.body_left_panel.ResumeLayout(false);
            this.product_panel.ResumeLayout(false);
            this.list_product_panel.ResumeLayout(false);
            this.product_list_flowLayoutPanel.ResumeLayout(false);
            this.categories_panel.ResumeLayout(false);
            this.categories_flowLayoutPanel.ResumeLayout(false);
            this.header_panel.ResumeLayout(false);
            this.profile_panel.ResumeLayout(false);
            this.search_panel.ResumeLayout(false);
            this.logo_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo_header)).EndInit();
            this.order_summary_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bg_panel;
        private System.Windows.Forms.Panel body_panel;
        private KimTools.WinForms.KtPanel order_summary_panel;
        private System.Windows.Forms.Panel header_panel;
        private KimTools.WinForms.KtTextBox txt_search;
        private System.Windows.Forms.Panel logo_panel;
        private KimTools.WinForms.KtPictureBox logo_header;
        private System.Windows.Forms.Panel search_panel;
        private KimTools.WinForms.KtLabel datetime_lbl;
        private System.Windows.Forms.Panel profile_panel;
        private KimTools.WinForms.KtLabel username_lbl;
        private System.Windows.Forms.Panel body_left_panel;
        private System.Windows.Forms.Panel categories_panel;
        private System.Windows.Forms.Panel product_panel;
        private Components.ProductCard productCard;
        private KimTools.WinForms.KtLabel category_title_lbl;
        private System.Windows.Forms.FlowLayoutPanel categories_flowLayoutPanel;
        private Components.CategoryCard categoryCard;
        private System.Windows.Forms.FlowLayoutPanel product_list_flowLayoutPanel;
        private Components.CategoryCard categoryCard1;
        private System.Windows.Forms.Panel list_product_panel;
        private KimTools.WinForms.KtLabel product_lbl;
        private Components.orders orders1;
        private Components.ProductCard productCard1;
        private KimTools.WinForms.KtTheme MainTheme;
    }
}