using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.ApiServices;
using POS.Dtos;

namespace POS.Components
{
    public partial class orders : UserControl
    {
        private readonly POSOrderService orderService = new POSOrderService();
        private readonly Dictionary<Guid, POSCartLine> cartLines = new Dictionary<Guid, POSCartLine>();

        public event EventHandler OrderPlaced;

        public orders()
        {
            InitializeComponent();
            cartItem1.Visible = false;
            cart_flowLayoutPanel.Controls.Clear();
            checkout_btn.Click += checkout_btn_Click;
            RefreshSummary();
        }

        public void AddProduct(POSProductVariantDto product)
        {
            POSCartLine line;
            if (cartLines.TryGetValue(product.VariantId, out line))
            {
                if (line.Quantity >= product.StockQuantity)
                {
                    MessageBox.Show("Cannot add more than available stock.", "POS Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                line.Quantity++;
            }
            else
            {
                line = new POSCartLine
                {
                    Product = product,
                    Quantity = 1
                };

                cartLines.Add(product.VariantId, line);
            }

            RenderCart();
        }

        private void RenderCart()
        {
            cart_flowLayoutPanel.SuspendLayout();
            cart_flowLayoutPanel.Controls.Clear();

            foreach (var line in cartLines.Values)
            {
                var item = new CartItem
                {
                    Size = cartItem1.Size,
                    Margin = cartItem1.Margin,
                    Padding = cartItem1.Padding,
                    BackColor = cartItem1.BackColor
                };

                item.SetCartItem(line.Product, line.Quantity);
                item.QuantityChanged += CartItem_QuantityChanged;
                cart_flowLayoutPanel.Controls.Add(item);
            }

            cart_flowLayoutPanel.ResumeLayout();
            RefreshSummary();
        }

        private void CartItem_QuantityChanged(CartItem item, int quantity)
        {
            POSCartLine line;
            if (!cartLines.TryGetValue(item.ProductVariantId, out line))
            {
                return;
            }

            if (quantity <= 0)
            {
                cartLines.Remove(item.ProductVariantId);
                RenderCart();
                return;
            }

            if (quantity > line.Product.StockQuantity)
            {
                MessageBox.Show($"Only {line.Product.StockQuantity} items are available in stock.", "POS Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RenderCart();
                return;
            }

            line.Quantity = quantity;
            RenderCart();
        }

        private async void checkout_btn_Click(object sender, EventArgs e)
        {
            if (!cartLines.Any())
            {
                MessageBox.Show("Please add at least one product before checkout.", "POS Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            checkout_btn.Enabled = false;

            var orderDto = new CreatePOSOrderDto
            {
                PaymentMethod = PaymentMethod.cod,
                CustomerName = "Walk-in Customer",
                CustomerPhone = string.Empty,
                Items = cartLines.Values.Select(line => new CreatePOSOrderItemDto
                {
                    ProductVariantId = line.Product.VariantId,
                    Quantity = line.Quantity
                }).ToList()
            };

            var result = await orderService.CreateOrderAsync(orderDto);
            checkout_btn.Enabled = true;

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "POS Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = result.Data?.Order;

            ShowOrderSuccessPopup(order);

            cartLines.Clear();
            RenderCart();
            OrderPlaced?.Invoke(this, EventArgs.Empty);
        }

        private void ShowOrderSuccessPopup(POSOrderDto order)
        {
            using (var successForm = new FrmOrderSuccess(order))
            {
                successForm.StartPosition = FormStartPosition.CenterScreen;
                successForm.ShowDialog(this.FindForm());
            }
        }

        private void RefreshSummary()
        {
            var totalItems = cartLines.Values.Sum(line => line.Quantity);
            var subtotal = cartLines.Values.Sum(line => line.Product.Price * line.Quantity);

            items_total_lbl.Text = $"{totalItems} (Items)";
            sub_total_lbl.Text = $"$ {subtotal:0.00}";
            total_pric_lbl.Text = $"$ {subtotal:0.00}";
            checkout_btn.Enabled = totalItems > 0;
        }

        private class POSCartLine
        {
            public POSProductVariantDto Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
