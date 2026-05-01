namespace POS
{
    partial class FrmOrderSuccess
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
            this.Icon_panel = new System.Windows.Forms.Panel();
            this.icon_picture = new KimTools.WinForms.KtPictureBox();
            this.Label_panel = new System.Windows.Forms.Panel();
            this.success_lbl = new KimTools.WinForms.KtLabel();
            this.ktLabel1 = new KimTools.WinForms.KtLabel();
            this.Print_btn = new KimTools.WinForms.KtButton();
            this.Close_btn = new KimTools.WinForms.KtButton();
            this.Icon_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_picture)).BeginInit();
            this.Label_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Icon_panel
            // 
            this.Icon_panel.BackColor = System.Drawing.Color.Transparent;
            this.Icon_panel.Controls.Add(this.icon_picture);
            this.Icon_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Icon_panel.Location = new System.Drawing.Point(0, 0);
            this.Icon_panel.Name = "Icon_panel";
            this.Icon_panel.Padding = new System.Windows.Forms.Padding(5);
            this.Icon_panel.Size = new System.Drawing.Size(604, 132);
            this.Icon_panel.TabIndex = 0;
            // 
            // icon_picture
            // 
            this.icon_picture.BackColor = System.Drawing.Color.Transparent;
            this.icon_picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icon_picture.Image = global::POS.Properties.Resources.mark;
            this.icon_picture.ImageBrush = ((KimTools.WinForms.KtBrushNone)(KimTools.WinForms.KtBrush.None));
            this.icon_picture.Location = new System.Drawing.Point(5, 5);
            this.icon_picture.Name = "icon_picture";
            this.icon_picture.Size = new System.Drawing.Size(594, 122);
            this.icon_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon_picture.TabIndex = 0;
            this.icon_picture.TabStop = false;
            // 
            // Label_panel
            // 
            this.Label_panel.BackColor = System.Drawing.Color.Transparent;
            this.Label_panel.Controls.Add(this.ktLabel1);
            this.Label_panel.Controls.Add(this.success_lbl);
            this.Label_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_panel.Location = new System.Drawing.Point(0, 132);
            this.Label_panel.Name = "Label_panel";
            this.Label_panel.Padding = new System.Windows.Forms.Padding(5);
            this.Label_panel.Size = new System.Drawing.Size(604, 98);
            this.Label_panel.TabIndex = 1;
            // 
            // success_lbl
            // 
            this.success_lbl.Align = System.Drawing.ContentAlignment.TopCenter;
            this.success_lbl.Auto = false;
            this.success_lbl.Background = KimTools.WinForms.KtColor.Empty;
            this.success_lbl.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.Black, null, 100);
            this.success_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.success_lbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.success_lbl.Location = new System.Drawing.Point(5, 5);
            this.success_lbl.Name = "success_lbl";
            this.success_lbl.Size = new System.Drawing.Size(594, 49);
            this.success_lbl.TabIndex = 0;
            this.success_lbl.Text = "Your Order is Success";
            this.success_lbl.Click += new System.EventHandler(this.ktLabel1_Click);
            // 
            // ktLabel1
            // 
            this.ktLabel1.Align = System.Drawing.ContentAlignment.TopCenter;
            this.ktLabel1.Auto = false;
            this.ktLabel1.Background = KimTools.WinForms.KtColor.Empty;
            this.ktLabel1.Color = new KimTools.WinForms.KtColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, 100);
            this.ktLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktLabel1.Location = new System.Drawing.Point(5, 54);
            this.ktLabel1.Name = "ktLabel1";
            this.ktLabel1.Size = new System.Drawing.Size(594, 39);
            this.ktLabel1.TabIndex = 1;
            this.ktLabel1.Text = "Thanks for your orders";
            // 
            // Print_btn
            // 
            this.Print_btn.BackColor = System.Drawing.Color.Transparent;
            this.Print_btn.Background = new KimTools.WinForms.KtBrushSolid(KimTools.WinForms.KtColor.PRIMARY);
            this.Print_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Print_btn.BorderWidth = 2F;
            this.Print_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Print_btn.Foreground = KimTools.WinForms.KtColor.Empty;
            this.Print_btn.Icon = "";
            this.Print_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.Print_btn.IconSize = 16;
            this.Print_btn.IconStroke = 2.5D;
            this.Print_btn.Location = new System.Drawing.Point(157, 262);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(120, 48);
            this.Print_btn.TabIndex = 2;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = false;
            // 
            // Close_btn
            // 
            this.Close_btn.BackColor = System.Drawing.Color.Transparent;
            this.Close_btn.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            this.Close_btn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.Close_btn.BorderWidth = 2F;
            this.Close_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Close_btn.Foreground = KimTools.WinForms.KtColor.Empty;
            this.Close_btn.Icon = "";
            this.Close_btn.IconColor = KimTools.WinForms.KtColor.Empty;
            this.Close_btn.IconSize = 16;
            this.Close_btn.IconStroke = 2.5D;
            this.Close_btn.Location = new System.Drawing.Point(304, 262);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(120, 48);
            this.Close_btn.TabIndex = 3;
            this.Close_btn.Text = "Close";
            this.Close_btn.UseVisualStyleBackColor = false;
            // 
            // FrmOrderSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Background = new KimTools.WinForms.KtBrushSolid(System.Drawing.Color.WhiteSmoke);
            this.ClientSize = new System.Drawing.Size(604, 343);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.Label_panel);
            this.Controls.Add(this.Icon_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrderSuccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmOrderSuccess";
            this.Icon_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_picture)).EndInit();
            this.Label_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Icon_panel;
        private KimTools.WinForms.KtPictureBox icon_picture;
        private System.Windows.Forms.Panel Label_panel;
        private KimTools.WinForms.KtLabel success_lbl;
        private KimTools.WinForms.KtLabel ktLabel1;
        private KimTools.WinForms.KtButton Print_btn;
        private KimTools.WinForms.KtButton Close_btn;
    }
}