using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimTools.WinForms;
using POS.Dtos;

namespace POS.Components
{
    public partial class CategoryCard : UserControl
    {
        public CategoryCard()
        {
            InitializeComponent();
        }

        public void SetCategory(CategoryDto category)
        {
            category_name_label.Text = category.CategoryName;
            total_product_lbl.Text = $"{category.ProductCount} Products";
            Tag = category;
        }

        public void SetSelected(bool selected)
        {
            if (selected)
            {
                bg_panel.Border = new KtBrushSolid(Color.Violet);
                return;
            }

            bg_panel.Border = new KtBrushSolid(Color.Gray);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
