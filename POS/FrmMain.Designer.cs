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
            this.body_left_panel = new System.Windows.Forms.Panel();
            this.product_panel = new System.Windows.Forms.Panel();
            this.product_footer_panel = new KimTools.WinForms.KtPanel();
            this.product_list_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categories_panel = new System.Windows.Forms.Panel();
            this.categories_flowLayout_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.Category_btn_template = new KimTools.WinForms.KtButton();
            this.prev_category_panel = new System.Windows.Forms.Panel();
            this.Prev_category_btn = new KimTools.WinForms.KtButton();
            this.next_category_panel = new System.Windows.Forms.Panel();
            this.next_category_btn = new KimTools.WinForms.KtButton();
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
            this.productCard1 = new POS.Components.ProductCard();
            this.bg_panel.SuspendLayout();
            this.body_panel.SuspendLayout();
            this.body_left_panel.SuspendLayout();
            this.product_panel.SuspendLayout();
            this.product_list_flowLayoutPanel.SuspendLayout();
            this.categories_panel.SuspendLayout();
            this.categories_flowLayout_panel.SuspendLayout();
            this.prev_category_panel.SuspendLayout();
            this.next_category_panel.SuspendLayout();
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
            this.MainTheme.InfoContent = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
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
            this.body_panel.Controls.Add(this.body_left_panel);
            this.body_panel.Controls.Add(this.order_summary_panel);
            this.body_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_panel.Location = new System.Drawing.Point(0, 63);
            this.body_panel.Name = "body_panel";
            this.body_panel.Padding = new System.Windows.Forms.Padding(3, 3, 8, 5);
            this.body_panel.Size = new System.Drawing.Size(1256, 606);
            this.body_panel.TabIndex = 1;
            // 
            // body_left_panel
            // 
            this.body_left_panel.Controls.Add(this.product_panel);
            this.body_left_panel.Controls.Add(this.categories_panel);
            this.body_left_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_left_panel.Location = new System.Drawing.Point(3, 3);
            this.body_left_panel.Name = "body_left_panel";
            this.body_left_panel.Size = new System.Drawing.Size(768, 598);
            this.body_left_panel.TabIndex = 1;
            // 
            // product_panel
            // 
            this.product_panel.Controls.Add(this.product_footer_panel);
            this.product_panel.Controls.Add(this.product_list_flowLayoutPanel);
            this.product_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product_panel.Location = new System.Drawing.Point(0, 47);
            this.product_panel.Name = "product_panel";
            this.product_panel.Padding = new System.Windows.Forms.Padding(4);
            this.product_panel.Size = new System.Drawing.Size(768, 551);
            this.product_panel.TabIndex = 1;
            // 
            // product_footer_panel
            // 
            this.product_footer_panel.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.BASE_2);
            this.product_footer_panel.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            this.product_footer_panel.BorderRadius = 24F;
            this.product_footer_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.product_footer_panel.BorderWidth = 1.5F;
            this.product_footer_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.product_footer_panel.Foreground = KimTools.WinForms.KtColor.Empty;
            this.product_footer_panel.Location = new System.Drawing.Point(4, 496);
            this.product_footer_panel.Name = "product_footer_panel";
            this.product_footer_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.product_footer_panel.Size = new System.Drawing.Size(760, 51);
            this.product_footer_panel.TabIndex = 1;
            // 
            // product_list_flowLayoutPanel
            // 
            this.product_list_flowLayoutPanel.Controls.Add(this.productCard1);
            this.product_list_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.product_list_flowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.product_list_flowLayoutPanel.Name = "product_list_flowLayoutPanel";
            this.product_list_flowLayoutPanel.Size = new System.Drawing.Size(760, 543);
            this.product_list_flowLayoutPanel.TabIndex = 0;
            this.product_list_flowLayoutPanel.WrapContents = false;
            // 
            // categories_panel
            // 
            this.categories_panel.Controls.Add(this.categories_flowLayout_panel);
            this.categories_panel.Controls.Add(this.prev_category_panel);
            this.categories_panel.Controls.Add(this.next_category_panel);
            this.categories_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categories_panel.Location = new System.Drawing.Point(0, 0);
            this.categories_panel.Name = "categories_panel";
            this.categories_panel.Size = new System.Drawing.Size(768, 47);
            this.categories_panel.TabIndex = 0;
            // 
            // categories_flowLayout_panel
            // 
            this.categories_flowLayout_panel.Controls.Add(this.Category_btn_template);
            this.categories_flowLayout_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categories_flowLayout_panel.Location = new System.Drawing.Point(50, 0);
            this.categories_flowLayout_panel.Name = "categories_flowLayout_panel";
            this.categories_flowLayout_panel.Padding = new System.Windows.Forms.Padding(1);
            this.categories_flowLayout_panel.Size = new System.Drawing.Size(661, 47);
            this.categories_flowLayout_panel.TabIndex = 2;
            this.categories_flowLayout_panel.WrapContents = false;
            // 
            // Category_btn_template
            // 
            this.Category_btn_template.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Category_btn_template.BackColor = System.Drawing.Color.Transparent;
            this.Category_btn_template.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.Category_btn_template.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Category_btn_template.BorderWidth = 2F;
            this.Category_btn_template.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category_btn_template.ForeColor = System.Drawing.Color.Black;
            this.Category_btn_template.Foreground = KimTools.WinForms.KtColor.Empty;
            this.Category_btn_template.Icon = "";
            this.Category_btn_template.IconColor = KimTools.WinForms.KtColor.Empty;
            this.Category_btn_template.IconSize = 16;
            this.Category_btn_template.IconStroke = 2.5D;
            this.Category_btn_template.Location = new System.Drawing.Point(4, 4);
            this.Category_btn_template.Name = "Category_btn_template";
            this.Category_btn_template.Padding = new System.Windows.Forms.Padding(5);
            this.Category_btn_template.Size = new System.Drawing.Size(105, 40);
            this.Category_btn_template.TabIndex = 0;
            this.Category_btn_template.Text = "Category";
            this.Category_btn_template.UseVisualStyleBackColor = false;
            this.Category_btn_template.Visible = false;
            // 
            // prev_category_panel
            // 
            this.prev_category_panel.Controls.Add(this.Prev_category_btn);
            this.prev_category_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.prev_category_panel.Location = new System.Drawing.Point(0, 0);
            this.prev_category_panel.Name = "prev_category_panel";
            this.prev_category_panel.Size = new System.Drawing.Size(50, 47);
            this.prev_category_panel.TabIndex = 1;
            // 
            // Prev_category_btn
            // 
            this.Prev_category_btn.BackColor = System.Drawing.Color.Transparent;
            this.Prev_category_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.Prev_category_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Prev_category_btn.BorderWidth = 0F;
            this.Prev_category_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Prev_category_btn.Font = new System.Drawing.Font("Moul", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Prev_category_btn.ForeColor = System.Drawing.Color.Black;
            this.Prev_category_btn.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.Prev_category_btn.Icon = "";
            this.Prev_category_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.Prev_category_btn.IconSize = 16;
            this.Prev_category_btn.IconStroke = 2.5D;
            this.Prev_category_btn.Location = new System.Drawing.Point(0, 0);
            this.Prev_category_btn.Name = "Prev_category_btn";
            this.Prev_category_btn.Padding = new System.Windows.Forms.Padding(0);
            this.Prev_category_btn.Size = new System.Drawing.Size(50, 47);
            this.Prev_category_btn.TabIndex = 1;
            this.Prev_category_btn.Text = "<";
            this.Prev_category_btn.UseVisualStyleBackColor = false;
            // 
            // next_category_panel
            // 
            this.next_category_panel.Controls.Add(this.next_category_btn);
            this.next_category_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.next_category_panel.Location = new System.Drawing.Point(711, 0);
            this.next_category_panel.Name = "next_category_panel";
            this.next_category_panel.Size = new System.Drawing.Size(57, 47);
            this.next_category_panel.TabIndex = 0;
            // 
            // next_category_btn
            // 
            this.next_category_btn.BackColor = System.Drawing.Color.Transparent;
            this.next_category_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.next_category_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.next_category_btn.BorderWidth = 0F;
            this.next_category_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.next_category_btn.Font = new System.Drawing.Font("Moul", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.next_category_btn.ForeColor = System.Drawing.Color.Black;
            this.next_category_btn.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.next_category_btn.Icon = "";
            this.next_category_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.next_category_btn.IconSize = 16;
            this.next_category_btn.IconStroke = 2.5D;
            this.next_category_btn.Location = new System.Drawing.Point(0, 0);
            this.next_category_btn.Name = "next_category_btn";
            this.next_category_btn.Padding = new System.Windows.Forms.Padding(0);
            this.next_category_btn.Size = new System.Drawing.Size(57, 47);
            this.next_category_btn.TabIndex = 0;
            this.next_category_btn.Text = ">";
            this.next_category_btn.UseVisualStyleBackColor = false;
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
            this.order_summary_panel.Location = new System.Drawing.Point(771, 3);
            this.order_summary_panel.Name = "order_summary_panel";
            this.order_summary_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.order_summary_panel.Size = new System.Drawing.Size(477, 598);
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
            this.exit_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.exit_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.exit_btn.BorderWidth = 2F;
            this.exit_btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.exit_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.ForeColor = System.Drawing.Color.Red;
            this.exit_btn.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.Red, null, 100);
            this.exit_btn.Icon = "tabler.outline.power";
            this.exit_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.exit_btn.IconSize = 22;
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
            this.search_panel.Padding = new System.Windows.Forms.Padding(2, 12, 2, 2);
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
            this.txt_search.Size = new System.Drawing.Size(385, 49);
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
            this.body_left_panel.ResumeLayout(false);
            this.product_panel.ResumeLayout(false);
            this.product_list_flowLayoutPanel.ResumeLayout(false);
            this.categories_panel.ResumeLayout(false);
            this.categories_flowLayout_panel.ResumeLayout(false);
            this.prev_category_panel.ResumeLayout(false);
            this.next_category_panel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel body_left_panel;
        private System.Windows.Forms.Panel categories_panel;
        private System.Windows.Forms.FlowLayoutPanel categories_flowLayout_panel;
        private System.Windows.Forms.Panel prev_category_panel;
        private System.Windows.Forms.Panel next_category_panel;
        private KimTools.WinForms.KtButton next_category_btn;
        private KimTools.WinForms.KtButton Prev_category_btn;
        private KimTools.WinForms.KtButton Category_btn_template;
        private System.Windows.Forms.Panel product_panel;
        private KimTools.WinForms.KtPanel product_footer_panel;
        private System.Windows.Forms.FlowLayoutPanel product_list_flowLayoutPanel;
        private Components.ProductCard productCard1;
    }
}