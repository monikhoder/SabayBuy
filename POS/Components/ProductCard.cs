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
using POS.Dtos;

namespace POS.Components
{
    public partial class ProductCard : UserControl
    {
        private static readonly HttpClient ImageClient = new HttpClient();
        public event Action<POSProductVariantDto> ProductSelected;

        public ProductCard()
        {
            InitializeComponent();
            AttachAddToCartHandlers(this);
        }

        public async void SetProduct(POSProductVariantDto product)
        {
            title_lbl.Text = product.ProductName;
            varient_lbl.Text = $"{product.VariantName} | SKU: {product.Sku}";
            price_lbl.Text = $"${product.Price:0.00}";
            Tag = product;

            var imageUrl = string.IsNullOrWhiteSpace(product.VariantImageUrl)
                ? product.ProductImageUrl
                : product.VariantImageUrl;

            await LoadProductImageAsync(imageUrl);
        }

        private void AttachAddToCartHandlers(Control parent)
        {
            parent.Click += ProductCard_Click;

            foreach (Control child in parent.Controls)
            {
                AttachAddToCartHandlers(child);
            }
        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            var product = Tag as POSProductVariantDto;
            if (product == null)
            {
                return;
            }

            ProductSelected?.Invoke(product);
        }

        private async Task LoadProductImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                ProductImageUrl.Image = global::POS.Properties.Resources.macbook;
                return;
            }

            try
            {
                var imageBytes = await ImageClient.GetByteArrayAsync(imageUrl);

                using (var memoryStream = new MemoryStream(imageBytes))
                using (var image = Image.FromStream(memoryStream))
                {
                    ProductImageUrl.Image = new Bitmap(image);
                }
            }
            catch
            {
                ProductImageUrl.Image = global::POS.Properties.Resources.macbook;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
