namespace POS.Components
{
    partial class CategoryCard
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
            this.total_product_lbl = new KimTools.WinForms.KtLabel();
            this.category_name_label = new KimTools.WinForms.KtLabel();
            this.image = new System.Windows.Forms.PictureBox();
            this.bg_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // bg_panel
            // 
            this.bg_panel.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.White);
            this.bg_panel.Border = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.Gray);
            this.bg_panel.BorderRadius = 18F;
            this.bg_panel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.bg_panel.BorderWidth = 2F;
            this.bg_panel.Controls.Add(this.total_product_lbl);
            this.bg_panel.Controls.Add(this.category_name_label);
            this.bg_panel.Controls.Add(this.image);
            this.bg_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bg_panel.Foreground = KimTools.WinForms.KtColor.Empty;
            this.bg_panel.Location = new System.Drawing.Point(2, 2);
            this.bg_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bg_panel.Name = "bg_panel";
            this.bg_panel.PatternColor = KimTools.WinForms.KtColor.Empty;
            this.bg_panel.Size = new System.Drawing.Size(86, 94);
            this.bg_panel.TabIndex = 0;
            // 
            // total_product_lbl
            // 
            this.total_product_lbl.Align = System.Drawing.ContentAlignment.TopCenter;
            this.total_product_lbl.Auto = false;
            this.total_product_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.total_product_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Gray, null, 100);
            this.total_product_lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.total_product_lbl.Location = new System.Drawing.Point(0, 70);
            this.total_product_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.total_product_lbl.Name = "total_product_lbl";
            this.total_product_lbl.Size = new System.Drawing.Size(86, 24);
            this.total_product_lbl.TabIndex = 2;
            this.total_product_lbl.Text = "20 Items";
            // 
            // category_name_label
            // 
            this.category_name_label.Align = System.Drawing.ContentAlignment.TopCenter;
            this.category_name_label.Auto = false;
            this.category_name_label.Background = KimTools.WinForms.KtColor.Empty;
            this.category_name_label.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.category_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.category_name_label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_name_label.Location = new System.Drawing.Point(0, 43);
            this.category_name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.category_name_label.Name = "category_name_label";
            this.category_name_label.Size = new System.Drawing.Size(86, 51);
            this.category_name_label.TabIndex = 1;
            this.category_name_label.Text = "All Categories";
            // 
            // image
            // 
            this.image.Dock = System.Windows.Forms.DockStyle.Top;
            this.image.Image = global::POS.Properties.Resources.keyboard_and_mouse;
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(86, 43);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CategoryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bg_panel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CategoryCard";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Size = new System.Drawing.Size(90, 98);
            this.bg_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KimTools.WinForms.KtPanel bg_panel;
        private System.Windows.Forms.PictureBox image;
        private KimTools.WinForms.KtLabel total_product_lbl;
        private KimTools.WinForms.KtLabel category_name_label;
    }
}
