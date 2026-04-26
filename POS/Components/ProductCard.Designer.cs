namespace POS.Components
{
    partial class ProductCard
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
            this.bg_panel = new KimTools.WinForms.KtPanel();
            this.body_panel = new System.Windows.Forms.Panel();
            this.varient_lbl = new System.Windows.Forms.Label();
            this.Add_to_cart_panel = new System.Windows.Forms.Panel();
            this.price_lbl = new System.Windows.Forms.Label();
            this.ktButton1 = new KimTools.WinForms.KtButton();
            this.title_lbl = new System.Windows.Forms.Label();
            this.ProductImageUrl = new System.Windows.Forms.PictureBox();
            this.bg_panel.SuspendLayout();
            this.body_panel.SuspendLayout();
            this.Add_to_cart_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductImageUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // bg_panel
            // 
            this.bg_panel.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.White);
            this.bg_panel.Border = new KimTools.WinForms.KtBrushGradient(KimTools.WinForms.KtColor.BASE_1, KimTools.WinForms.KtColor.BASE_3);
            this.bg_panel.BorderRadius = 24F;
            this.bg_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.bg_panel.BorderWidth = 0F;
            this.bg_panel.Controls.Add(this.body_panel);
            this.bg_panel.Controls.Add(this.ProductImageUrl);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg_panel.Foreground = KimTools.WinForms.KtColor.Empty;
            this.bg_panel.Location = new System.Drawing.Point(5, 5);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.Padding = new System.Windows.Forms.Padding(8);
            this.bg_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.bg_panel.Size = new System.Drawing.Size(198, 271);
            this.bg_panel.TabIndex = 0;
            // 
            // body_panel
            // 
            this.body_panel.Controls.Add(this.varient_lbl);
            this.body_panel.Controls.Add(this.Add_to_cart_panel);
            this.body_panel.Controls.Add(this.title_lbl);
            this.body_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body_panel.Location = new System.Drawing.Point(8, 103);
            this.body_panel.Name = "body_panel";
            this.body_panel.Padding = new System.Windows.Forms.Padding(6);
            this.body_panel.Size = new System.Drawing.Size(182, 160);
            this.body_panel.TabIndex = 1;
            // 
            // varient_lbl
            // 
            this.varient_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.varient_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varient_lbl.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.varient_lbl.Location = new System.Drawing.Point(6, 44);
            this.varient_lbl.Name = "varient_lbl";
            this.varient_lbl.Size = new System.Drawing.Size(170, 69);
            this.varient_lbl.TabIndex = 4;
            this.varient_lbl.Text = "{Varient}";
            // 
            // Add_to_cart_panel
            // 
            this.Add_to_cart_panel.Controls.Add(this.price_lbl);
            this.Add_to_cart_panel.Controls.Add(this.ktButton1);
            this.Add_to_cart_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Add_to_cart_panel.Location = new System.Drawing.Point(6, 113);
            this.Add_to_cart_panel.Name = "Add_to_cart_panel";
            this.Add_to_cart_panel.Size = new System.Drawing.Size(170, 41);
            this.Add_to_cart_panel.TabIndex = 3;
            // 
            // price_lbl
            // 
            this.price_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.price_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.price_lbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.price_lbl.Location = new System.Drawing.Point(0, 0);
            this.price_lbl.Name = "price_lbl";
            this.price_lbl.Size = new System.Drawing.Size(107, 41);
            this.price_lbl.TabIndex = 5;
            this.price_lbl.Text = "{Price}";
            this.price_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ktButton1
            // 
            this.ktButton1.BackColor = System.Drawing.Color.Transparent;
            this.ktButton1.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Transparent);
            this.ktButton1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ktButton1.BorderWidth = 0F;
            this.ktButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ktButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ktButton1.Foreground = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))), null, 100);
            this.ktButton1.Icon = "tabler.outline.shopping_cart_plus";
            this.ktButton1.IconColor = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))), null, 100);
            this.ktButton1.IconSize = 22;
            this.ktButton1.IconStroke = 2.5D;
            this.ktButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ktButton1.Location = new System.Drawing.Point(107, 0);
            this.ktButton1.Name = "ktButton1";
            this.ktButton1.Padding = new System.Windows.Forms.Padding(3);
            this.ktButton1.Size = new System.Drawing.Size(63, 41);
            this.ktButton1.TabIndex = 1;
            this.ktButton1.UseVisualStyleBackColor = false;
            // 
            // title_lbl
            // 
            this.title_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.title_lbl.Location = new System.Drawing.Point(6, 6);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(170, 38);
            this.title_lbl.TabIndex = 1;
            this.title_lbl.Text = "{Title}";
            this.title_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductImageUrl
            // 
            this.ProductImageUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductImageUrl.Image = global::POS.Properties.Resources.macbook;
            this.ProductImageUrl.Location = new System.Drawing.Point(8, 8);
            this.ProductImageUrl.Name = "ProductImageUrl";
            this.ProductImageUrl.Size = new System.Drawing.Size(182, 95);
            this.ProductImageUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductImageUrl.TabIndex = 0;
            this.ProductImageUrl.TabStop = false;
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bg_panel);
            this.Name = "ProductCard";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(208, 281);
            this.bg_panel.ResumeLayout(false);
            this.body_panel.ResumeLayout(false);
            this.Add_to_cart_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductImageUrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KimTools.WinForms.KtPanel bg_panel;
        private System.Windows.Forms.Panel body_panel;
        private System.Windows.Forms.PictureBox ProductImageUrl;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Panel Add_to_cart_panel;
        private System.Windows.Forms.Label varient_lbl;
        private KimTools.WinForms.KtButton ktButton1;
        private System.Windows.Forms.Label price_lbl;
    }
}
