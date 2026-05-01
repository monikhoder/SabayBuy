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
    public partial class CartItem : UserControl
    {
        private static readonly HttpClient ImageClient = new HttpClient();
        private bool suppressQuantityChanged;

        public event Action<CartItem, int> QuantityChanged;
        public Guid ProductVariantId { get; private set; }
        public int Quantity { get; private set; }

        public CartItem()
        {
            InitializeComponent();
            qty_txt.KeyPress += qty_txt_KeyPress;
            qty_txt.TextChanged += qty_txt_TextChanged;
            qty_txt.Leave += qty_txt_Leave;
            Delete_btn.Click += Delete_btn_Click;
        }

        public async void SetCartItem(POSProductVariantDto product, int quantity)
        {
            ProductVariantId = product.VariantId;
            Quantity = quantity;
            Tag = product;

            product_namelbl.Text = product.ProductName;
            varient_lbl.Text = $"{product.VariantName} | SKU: {product.Sku}";
            price_lbl.Text = $"${product.Price * quantity:0.00}";

            suppressQuantityChanged = true;
            qty_txt.Text = quantity.ToString();
            suppressQuantityChanged = false;

            var imageUrl = string.IsNullOrWhiteSpace(product.VariantImageUrl)
                ? product.ProductImageUrl
                : product.VariantImageUrl;

            await LoadProductImageAsync(imageUrl);
        }

        private void product_Url_Click(object sender, EventArgs e)
        {

        }

        private void plus_btn_Click(object sender, EventArgs e)
        {

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            QuantityChanged?.Invoke(this, 0);
        }

        private void qty_txt_TextChanged(object sender, EventArgs e)
        {
            if (suppressQuantityChanged)
            {
                return;
            }

            if (!IsDigitsOnly(qty_txt.Text))
            {
                var digitsOnly = new string(qty_txt.Text.Where(char.IsDigit).ToArray());
                SetQuantityText(digitsOnly);
                return;
            }

            if (string.IsNullOrWhiteSpace(qty_txt.Text))
            {
                return;
            }

            int quantity;
            if (!int.TryParse(qty_txt.Text, out quantity))
            {
                return;
            }

            if (quantity < 1)
            {
                quantity = 1;
                SetQuantityText(quantity.ToString());
            }

            Quantity = quantity;
            QuantityChanged?.Invoke(this, quantity);
        }

        private void qty_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void qty_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(qty_txt.Text))
            {
                SetQuantityText("1");
                Quantity = 1;
                QuantityChanged?.Invoke(this, Quantity);
            }
        }

        private bool IsDigitsOnly(string text)
        {
            return text.All(char.IsDigit);
        }

        private void SetQuantityText(string text)
        {
            suppressQuantityChanged = true;
            qty_txt.Text = text;
            qty_txt.SelectionStart = qty_txt.Text.Length;
            suppressQuantityChanged = false;
        }

        private async Task LoadProductImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                product_Url.Image = global::POS.Properties.Resources.macbook;
                return;
            }

            try
            {
                var imageBytes = await ImageClient.GetByteArrayAsync(imageUrl);

                using (var memoryStream = new MemoryStream(imageBytes))
                using (var image = Image.FromStream(memoryStream))
                {
                    product_Url.Image = new Bitmap(image);
                }
            }
            catch
            {
                product_Url.Image = global::POS.Properties.Resources.macbook;
            }

        }
    }
}
