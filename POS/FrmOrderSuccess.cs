using KimTools.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Dtos;

namespace POS
{
    public partial class FrmOrderSuccess : KtWindow
    {
        private readonly POSOrderDto order;

        public FrmOrderSuccess()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Close_btn.Click += Close_btn_Click;
            Print_btn.Click += Print_btn_Click;
        }

        public FrmOrderSuccess(POSOrderDto order) : this()
        {
            this.order = order;
        }

        private void ktLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Print_btn_Click(object sender, EventArgs e)
        {
            if (order == null)
            {
                MessageBox.Show("No order data found for printing.", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var printer = new ReceiptPrinter(order);
                printer.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class ReceiptPrinter
    {
        private const int PaperWidth = 315;
        private readonly POSOrderDto order;

        public ReceiptPrinter(POSOrderDto order)
        {
            this.order = order ?? throw new ArgumentNullException(nameof(order));
        }

        public void Print()
        {
            using (var document = new PrintDocument())
            {
                document.DocumentName = $"Sabay Buy Receipt {order.Id}";
                document.DefaultPageSettings.PaperSize = new PaperSize("80mm Receipt", PaperWidth, 1200);
                document.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
                document.PrintController = new StandardPrintController();
                document.PrintPage += PrintPage;
                document.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var bounds = e.MarginBounds;
            var y = bounds.Top;

            using (var titleFont = new Font("Consolas", 11, FontStyle.Bold))
            using (var boldFont = new Font("Consolas", 8, FontStyle.Bold))
            using (var normalFont = new Font("Consolas", 8))
            using (var smallFont = new Font("Consolas", 7))
            using (var center = new StringFormat { Alignment = StringAlignment.Center })
            {
                DrawLogo(g, bounds, ref y);
                DrawCenter(g, "SABAY BUY", titleFont, bounds, ref y, center);
                DrawCenter(g, "POS Receipt", normalFont, bounds, ref y, center);
                DrawLine(g, normalFont, bounds, ref y);

                DrawText(g, $"Order : #{ShortOrderId(order.Id)}", normalFont, bounds.Left, ref y);
                DrawText(g, $"Date  : {GetOrderDate():dd/MM/yyyy hh:mm tt}", normalFont, bounds.Left, ref y);
                DrawText(g, $"Cashier: {NullText(order.BuyerEmail)}", normalFont, bounds.Left, ref y);

                if (order.ShippingAddress != null)
                {
                    DrawText(g, $"Customer: {NullText(order.ShippingAddress.FullName)}", normalFont, bounds.Left, ref y);
                }

                DrawLine(g, normalFont, bounds, ref y);

                if (order.OrderItems != null)
                {
                    foreach (var item in order.OrderItems)
                    {
                        DrawWrappedText(g, NullText(item.ProductName), normalFont, bounds, ref y);

                        if (!string.IsNullOrWhiteSpace(item.VariantName))
                        {
                            DrawWrappedText(g, $"  {item.VariantName}", smallFont, bounds, ref y);
                        }

                        var lineTotal = item.Price * item.Quantity;
                        DrawText(g, PadBoth($"  {item.Quantity} x ${item.Price:0.00}", $"${lineTotal:0.00}", 32), normalFont, bounds.Left, ref y);
                    }
                }

                DrawLine(g, normalFont, bounds, ref y);
                DrawAmount(g, "Subtotal", GetSubtotal(), normalFont, bounds, ref y);

                if (order.DeliveryPrice > 0)
                {
                    DrawAmount(g, "Delivery", order.DeliveryPrice, normalFont, bounds, ref y);
                }

                DrawLine(g, normalFont, bounds, ref y);
                DrawAmount(g, "TOTAL", GetTotal(), boldFont, bounds, ref y);
                DrawLine(g, normalFont, bounds, ref y);

                DrawLine(g, normalFont, bounds, ref y);
                DrawCenter(g, "Thank you!", boldFont, bounds, ref y, center);
            }

            e.HasMorePages = false;
        }

        private DateTime GetOrderDate()
        {
            return order.OrderDate == default(DateTime) ? DateTime.Now : order.OrderDate;
        }

        private decimal GetSubtotal()
        {
            if (order.Subtotal > 0) return order.Subtotal;
            return order.OrderItems == null ? 0 : order.OrderItems.Sum(x => x.Price * x.Quantity);
        }

        private decimal GetTotal()
        {
            return order.Total > 0 ? order.Total : GetSubtotal() + order.DeliveryPrice;
        }

        private static void DrawAmount(Graphics g, string label, decimal amount, Font font, Rectangle bounds, ref int y)
        {
            DrawText(g, PadBoth(label, $"${amount:0.00}", 32), font, bounds.Left, ref y);
        }

        private static void DrawLogo(Graphics g, Rectangle bounds, ref int y)
        {
            var logo = Properties.Resources.sabay_buy_logo_header;
            if (logo == null) return;

            var logoWidth = Math.Min(150, bounds.Width);
            var logoHeight = (int)Math.Round((double)logo.Height / logo.Width * logoWidth);
            var logoX = bounds.Left + (bounds.Width - logoWidth) / 2;

            g.DrawImage(logo, logoX, y, logoWidth, logoHeight);
            y += logoHeight + 6;
        }

        private static void DrawCenter(Graphics g, string text, Font font, Rectangle bounds, ref int y, StringFormat format)
        {
            g.DrawString(text, font, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, font.Height + 4), format);
            y += font.Height + 4;
        }

        private static void DrawText(Graphics g, string text, Font font, int x, ref int y)
        {
            g.DrawString(text, font, Brushes.Black, x, y);
            y += font.Height + 3;
        }

        private static void DrawWrappedText(Graphics g, string text, Font font, Rectangle bounds, ref int y)
        {
            var size = g.MeasureString(text, font, bounds.Width);
            g.DrawString(text, font, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, size.Height));
            y += (int)Math.Ceiling(size.Height) + 2;
        }

        private static void DrawLine(Graphics g, Font font, Rectangle bounds, ref int y)
        {
            DrawText(g, new string('-', 32), font, bounds.Left, ref y);
        }

        private static string ShortOrderId(Guid id)
        {
            return id == Guid.Empty ? "N/A" : id.ToString("N").Substring(0, 8).ToUpper();
        }

        private static string NullText(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "N/A" : value;
        }

        private static string PadBoth(string left, string right, int width)
        {
            var spaces = width - left.Length - right.Length;
            if (spaces < 1) spaces = 1;
            return left + new string(' ', spaces) + right;
        }
    }
}
