using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimTools.WinForms;
using POS.ApiServices;
using POS.Dtos;

namespace POS.Components
{
    public partial class CategoryCard : UserControl
    {
        private static readonly HttpClient ImageClient = new HttpClient();

        public CategoryCard()
        {
            InitializeComponent();
        }

        public async void SetCategory(CategoryDto category)
        {
            category_name_label.Text = category.CategoryName;
            total_product_lbl.Text = $"{category.ProductCount} Products";
            Tag = category;

            await LoadCategoryIconAsync(category.Icon);
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

        private async Task LoadCategoryIconAsync(string iconUrl)
        {
            image.Image = global::POS.Properties.Resources.keyboard_and_mouse;

            if (string.IsNullOrWhiteSpace(iconUrl))
            {
                return;
            }

            try
            {
                var finalUrl = BuildImageUrl(iconUrl);
                var imageBytes = await ImageClient.GetByteArrayAsync(finalUrl);

                using (var memoryStream = new MemoryStream(imageBytes))
                using (var loadedImage = Image.FromStream(memoryStream))
                {
                    image.Image = new Bitmap(loadedImage);
                }
            }
            catch
            {
                image.Image = global::POS.Properties.Resources.keyboard_and_mouse;
            }
        }

        private static string BuildImageUrl(string iconUrl)
        {
            Uri absoluteUri;
            if (Uri.TryCreate(iconUrl, UriKind.Absolute, out absoluteUri))
            {
                return absoluteUri.ToString();
            }

            var apiBaseAddress = POSAccountService.GetApiBaseAddress();
            var rootAddress = new Uri(apiBaseAddress, "../");
            return new Uri(rootAddress, iconUrl.TrimStart('/')).ToString();
        }
    }
}
