namespace POS.Components
{
    partial class orders
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
            this.items_lbl = new KimTools.WinForms.KtLabel();
            this.cart_panel = new System.Windows.Forms.Panel();
            this.cart_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.amount_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.total_pric_lbl = new KimTools.WinForms.KtLabel();
            this.ktLabel3 = new KimTools.WinForms.KtLabel();
            this.ktDivider1 = new KimTools.WinForms.KtDivider();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sub_total_lbl = new KimTools.WinForms.KtLabel();
            this.ktLabel4 = new KimTools.WinForms.KtLabel();
            this.total_item_panel = new System.Windows.Forms.Panel();
            this.items_total_lbl = new KimTools.WinForms.KtLabel();
            this.ktLabel1 = new KimTools.WinForms.KtLabel();
            this.paymentlbl = new KimTools.WinForms.KtLabel();
            this.payment_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cash_btn = new KimTools.WinForms.KtButton();
            this.ktButton2 = new KimTools.WinForms.KtButton();
            this.checkout_btn = new KimTools.WinForms.KtButton();
            this.payment_panel = new System.Windows.Forms.Panel();
            this.ktTheme1 = new KimTools.WinForms.KtTheme(this.components);
            this.cartItem1 = new POS.Components.CartItem();
            this.cart_panel.SuspendLayout();
            this.cart_flowLayoutPanel.SuspendLayout();
            this.amount_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.total_item_panel.SuspendLayout();
            this.payment_flowLayoutPanel.SuspendLayout();
            this.payment_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // items_lbl
            // 
            this.items_lbl.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.items_lbl.Auto = false;
            this.items_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.items_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.items_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.items_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.items_lbl.Location = new System.Drawing.Point(0, 0);
            this.items_lbl.Name = "items_lbl";
            this.items_lbl.Size = new System.Drawing.Size(469, 30);
            this.items_lbl.TabIndex = 0;
            this.items_lbl.Text = "Detail Items";
            // 
            // cart_panel
            // 
            this.cart_panel.Controls.Add(this.cart_flowLayoutPanel);
            this.cart_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cart_panel.Location = new System.Drawing.Point(0, 30);
            this.cart_panel.Name = "cart_panel";
            this.cart_panel.Padding = new System.Windows.Forms.Padding(1);
            this.cart_panel.Size = new System.Drawing.Size(469, 686);
            this.cart_panel.TabIndex = 1;
            // 
            // cart_flowLayoutPanel
            // 
            this.cart_flowLayoutPanel.AutoScroll = true;
            this.cart_flowLayoutPanel.Controls.Add(this.cartItem1);
            this.cart_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cart_flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.cart_flowLayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.cart_flowLayoutPanel.Name = "cart_flowLayoutPanel";
            this.cart_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.cart_flowLayoutPanel.Size = new System.Drawing.Size(467, 684);
            this.cart_flowLayoutPanel.TabIndex = 0;
            this.cart_flowLayoutPanel.WrapContents = false;
            // 
            // amount_panel
            // 
            this.amount_panel.Controls.Add(this.panel2);
            this.amount_panel.Controls.Add(this.ktDivider1);
            this.amount_panel.Controls.Add(this.panel1);
            this.amount_panel.Controls.Add(this.total_item_panel);
            this.amount_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.amount_panel.Location = new System.Drawing.Point(0, 412);
            this.amount_panel.Name = "amount_panel";
            this.amount_panel.Size = new System.Drawing.Size(469, 150);
            this.amount_panel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.total_pric_lbl);
            this.panel2.Controls.Add(this.ktLabel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 37);
            this.panel2.TabIndex = 3;
            // 
            // total_pric_lbl
            // 
            this.total_pric_lbl.Align = System.Drawing.ContentAlignment.MiddleRight;
            this.total_pric_lbl.Auto = false;
            this.total_pric_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.total_pric_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.total_pric_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.total_pric_lbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_pric_lbl.Location = new System.Drawing.Point(239, 0);
            this.total_pric_lbl.Name = "total_pric_lbl";
            this.total_pric_lbl.Size = new System.Drawing.Size(230, 37);
            this.total_pric_lbl.TabIndex = 1;
            this.total_pric_lbl.Text = "$ 156.75";
            // 
            // ktLabel3
            // 
            this.ktLabel3.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.ktLabel3.Auto = false;
            this.ktLabel3.Background = KimTools.WinForms.KtColor.Empty;
            this.ktLabel3.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.ktLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktLabel3.Location = new System.Drawing.Point(0, 0);
            this.ktLabel3.Name = "ktLabel3";
            this.ktLabel3.Size = new System.Drawing.Size(176, 37);
            this.ktLabel3.TabIndex = 0;
            this.ktLabel3.Text = "Total";
            // 
            // ktDivider1
            // 
            this.ktDivider1.BackColor = System.Drawing.Color.Transparent;
            this.ktDivider1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ktDivider1.DashCap = KimTools.WinForms.KtDivider.CapStyles.Round;
            this.ktDivider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ktDivider1.LineColor = KimTools.WinForms.KtColor.SECONDARY;
            this.ktDivider1.LineStyle = KimTools.WinForms.KtDivider.LineStyles.Dash;
            this.ktDivider1.Location = new System.Drawing.Point(0, 74);
            this.ktDivider1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ktDivider1.Name = "ktDivider1";
            this.ktDivider1.Orientation = KimTools.WinForms.KtDivider.LineOrientation.Horizontal;
            this.ktDivider1.Size = new System.Drawing.Size(469, 23);
            this.ktDivider1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sub_total_lbl);
            this.panel1.Controls.Add(this.ktLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 37);
            this.panel1.TabIndex = 1;
            // 
            // sub_total_lbl
            // 
            this.sub_total_lbl.Align = System.Drawing.ContentAlignment.MiddleRight;
            this.sub_total_lbl.Auto = false;
            this.sub_total_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.sub_total_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.sub_total_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.sub_total_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub_total_lbl.Location = new System.Drawing.Point(239, 0);
            this.sub_total_lbl.Name = "sub_total_lbl";
            this.sub_total_lbl.Size = new System.Drawing.Size(230, 37);
            this.sub_total_lbl.TabIndex = 1;
            this.sub_total_lbl.Text = "$ 156.75";
            // 
            // ktLabel4
            // 
            this.ktLabel4.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.ktLabel4.Auto = false;
            this.ktLabel4.Background = KimTools.WinForms.KtColor.Empty;
            this.ktLabel4.Color = KimTools.WinForms.KtColor.SECONDARY;
            this.ktLabel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktLabel4.Location = new System.Drawing.Point(0, 0);
            this.ktLabel4.Name = "ktLabel4";
            this.ktLabel4.Size = new System.Drawing.Size(176, 37);
            this.ktLabel4.TabIndex = 0;
            this.ktLabel4.Text = "Subtotal";
            // 
            // total_item_panel
            // 
            this.total_item_panel.Controls.Add(this.items_total_lbl);
            this.total_item_panel.Controls.Add(this.ktLabel1);
            this.total_item_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.total_item_panel.Location = new System.Drawing.Point(0, 0);
            this.total_item_panel.Name = "total_item_panel";
            this.total_item_panel.Size = new System.Drawing.Size(469, 37);
            this.total_item_panel.TabIndex = 0;
            // 
            // items_total_lbl
            // 
            this.items_total_lbl.Align = System.Drawing.ContentAlignment.MiddleRight;
            this.items_total_lbl.Auto = false;
            this.items_total_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.items_total_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.items_total_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.items_total_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.items_total_lbl.Location = new System.Drawing.Point(239, 0);
            this.items_total_lbl.Name = "items_total_lbl";
            this.items_total_lbl.Size = new System.Drawing.Size(230, 37);
            this.items_total_lbl.TabIndex = 1;
            this.items_total_lbl.Text = "5 (Items)";
            // 
            // ktLabel1
            // 
            this.ktLabel1.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.ktLabel1.Auto = false;
            this.ktLabel1.Background = KimTools.WinForms.KtColor.Empty;
            this.ktLabel1.Color = KimTools.WinForms.KtColor.SECONDARY;
            this.ktLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktLabel1.Location = new System.Drawing.Point(0, 0);
            this.ktLabel1.Name = "ktLabel1";
            this.ktLabel1.Size = new System.Drawing.Size(176, 37);
            this.ktLabel1.TabIndex = 0;
            this.ktLabel1.Text = "Items";
            // 
            // paymentlbl
            // 
            this.paymentlbl.Align = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentlbl.Auto = false;
            this.paymentlbl.Background = KimTools.WinForms.KtColor.Empty;
            this.paymentlbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.paymentlbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paymentlbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentlbl.Location = new System.Drawing.Point(0, 562);
            this.paymentlbl.Name = "paymentlbl";
            this.paymentlbl.Size = new System.Drawing.Size(469, 37);
            this.paymentlbl.TabIndex = 3;
            this.paymentlbl.Text = "Payment Method";
            // 
            // payment_flowLayoutPanel
            // 
            this.payment_flowLayoutPanel.Controls.Add(this.cash_btn);
            this.payment_flowLayoutPanel.Controls.Add(this.ktButton2);
            this.payment_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payment_flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.payment_flowLayoutPanel.Name = "payment_flowLayoutPanel";
            this.payment_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.payment_flowLayoutPanel.Size = new System.Drawing.Size(469, 68);
            this.payment_flowLayoutPanel.TabIndex = 4;
            // 
            // cash_btn
            // 
            this.cash_btn.BackColor = System.Drawing.Color.Transparent;
            this.cash_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.White);
            this.cash_btn.Border = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.PRIMARY);
            this.cash_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.cash_btn.BorderWidth = 2F;
            this.cash_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cash_btn.Foreground = KimTools.WinForms.KtColor.PRIMARY;
            this.cash_btn.Icon = "";
            this.cash_btn.IconColor = KimTools.WinForms.KtColor.PRIMARY;
            this.cash_btn.IconSize = 15;
            this.cash_btn.IconStroke = 2.5D;
            this.cash_btn.Location = new System.Drawing.Point(5, 5);
            this.cash_btn.Name = "cash_btn";
            this.cash_btn.Size = new System.Drawing.Size(120, 50);
            this.cash_btn.TabIndex = 0;
            this.cash_btn.Text = "Cash";
            this.cash_btn.UseVisualStyleBackColor = false;
            // 
            // ktButton2
            // 
            this.ktButton2.BackColor = System.Drawing.Color.Transparent;
            this.ktButton2.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.White);
            this.ktButton2.Border = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.SECONDARY);
            this.ktButton2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ktButton2.BorderWidth = 2F;
            this.ktButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktButton2.ForeColor = System.Drawing.Color.DimGray;
            this.ktButton2.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.DimGray, null, 100);
            this.ktButton2.Icon = "";
            this.ktButton2.IconColor = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.ktButton2.IconSize = 15;
            this.ktButton2.IconStroke = 2.5D;
            this.ktButton2.Location = new System.Drawing.Point(131, 5);
            this.ktButton2.Name = "ktButton2";
            this.ktButton2.Size = new System.Drawing.Size(120, 50);
            this.ktButton2.TabIndex = 1;
            this.ktButton2.Text = "QR";
            this.ktButton2.UseVisualStyleBackColor = false;
            // 
            // checkout_btn
            // 
            this.checkout_btn.BackColor = System.Drawing.Color.Transparent;
            this.checkout_btn.Background = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.PRIMARY, System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))));
            this.checkout_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.checkout_btn.BorderWidth = 2F;
            this.checkout_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkout_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkout_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkout_btn.Foreground = KimTools.WinForms.KtColor.Empty;
            this.checkout_btn.Icon = "";
            this.checkout_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.checkout_btn.IconSize = 16;
            this.checkout_btn.IconStroke = 2.5D;
            this.checkout_btn.Location = new System.Drawing.Point(0, 667);
            this.checkout_btn.Name = "checkout_btn";
            this.checkout_btn.Size = new System.Drawing.Size(469, 49);
            this.checkout_btn.TabIndex = 5;
            this.checkout_btn.Text = "Checkout";
            this.checkout_btn.UseVisualStyleBackColor = false;
            // 
            // payment_panel
            // 
            this.payment_panel.Controls.Add(this.payment_flowLayoutPanel);
            this.payment_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.payment_panel.Location = new System.Drawing.Point(0, 599);
            this.payment_panel.Name = "payment_panel";
            this.payment_panel.Size = new System.Drawing.Size(469, 68);
            this.payment_panel.TabIndex = 6;
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
            // cartItem1
            // 
            this.cartItem1.BackColor = System.Drawing.Color.Transparent;
            this.cartItem1.Location = new System.Drawing.Point(5, 5);
            this.cartItem1.Name = "cartItem1";
            this.cartItem1.Padding = new System.Windows.Forms.Padding(5);
            this.cartItem1.Size = new System.Drawing.Size(459, 128);
            this.cartItem1.TabIndex = 0;
            // 
            // orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.amount_panel);
            this.Controls.Add(this.paymentlbl);
            this.Controls.Add(this.payment_panel);
            this.Controls.Add(this.checkout_btn);
            this.Controls.Add(this.cart_panel);
            this.Controls.Add(this.items_lbl);
            this.Name = "orders";
            this.Size = new System.Drawing.Size(469, 716);
            this.cart_panel.ResumeLayout(false);
            this.cart_flowLayoutPanel.ResumeLayout(false);
            this.amount_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.total_item_panel.ResumeLayout(false);
            this.payment_flowLayoutPanel.ResumeLayout(false);
            this.payment_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KimTools.WinForms.KtLabel items_lbl;
        private System.Windows.Forms.Panel cart_panel;
        private System.Windows.Forms.Panel amount_panel;
        private System.Windows.Forms.Panel panel1;
        private KimTools.WinForms.KtLabel sub_total_lbl;
        private KimTools.WinForms.KtLabel ktLabel4;
        private System.Windows.Forms.Panel total_item_panel;
        private KimTools.WinForms.KtLabel items_total_lbl;
        private KimTools.WinForms.KtLabel ktLabel1;
        private System.Windows.Forms.Panel panel2;
        private KimTools.WinForms.KtLabel total_pric_lbl;
        private KimTools.WinForms.KtLabel ktLabel3;
        private KimTools.WinForms.KtDivider ktDivider1;
        private KimTools.WinForms.KtLabel paymentlbl;
        private System.Windows.Forms.FlowLayoutPanel payment_flowLayoutPanel;
        private KimTools.WinForms.KtButton cash_btn;
        private KimTools.WinForms.KtButton checkout_btn;
        private System.Windows.Forms.Panel payment_panel;
        private KimTools.WinForms.KtButton ktButton2;
        private KimTools.WinForms.KtTheme ktTheme1;
        private System.Windows.Forms.FlowLayoutPanel cart_flowLayoutPanel;
        private CartItem cartItem1;
    }
}
