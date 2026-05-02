using System.Globalization;
using Core.Entities.OrderAggregate;
using Core.Interface;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Infrastructure.Services;

public class InvoicePdfService : IInvoicePdfService
{
    private static readonly CultureInfo CurrencyCulture = CultureInfo.GetCultureInfo("en-US");

    public byte[] GenerateOrderInvoice(Order order, string? logoPath = null)
    {
        var deliveryPrice = order.DeliveryMethod?.Price ?? 0;
        var total = order.Subtotal + deliveryPrice;

        return Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A5);
                page.Margin(20);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(9));

                page.Header().Element(container => ComposeHeader(container, order, logoPath));

                page.Content()
                    .PaddingVertical(12)
                    .Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Element(container => ComposeCustomerInfo(container, order));
                        column.Item().Element(container => ComposeItemsTable(container, order));
                        column.Item().AlignRight().Width(170).Element(container => ComposeTotals(container, order.Subtotal, deliveryPrice, total));
                    });

                page.Footer()
                    .BorderTop(1)
                    .BorderColor(Colors.Grey.Lighten2)
                    .PaddingTop(8)
                    .Row(row =>
                    {
                        row.RelativeItem().Text("Thank you for shopping with SabayBuy.").FontSize(8).FontColor(Colors.Grey.Darken1);
                        row.AutoItem().Text(text =>
                        {
                            text.Span("Page ").FontSize(8).FontColor(Colors.Grey.Darken1);
                            text.CurrentPageNumber();
                            text.Span(" / ").FontSize(8).FontColor(Colors.Grey.Darken1);
                            text.TotalPages();
                        });
                    });
            });
        }).GeneratePdf();
    }

    private static void ComposeHeader(IContainer container, Order order, string? logoPath)
    {
        container.Column(column =>
        {
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(left =>
                {
                    if (!string.IsNullOrWhiteSpace(logoPath) && File.Exists(logoPath))
                    {
                        left.Item()
                            .Width(120)
                            .Height(38)
                            .Image(logoPath)
                            .FitArea();
                    }
                    else
                    {
                        left.Item().Text("SabayBuy").FontSize(20).Bold().FontColor(Colors.Blue.Darken2);
                    }

                    left.Item().Text("Invoice").FontSize(11).FontColor(Colors.Grey.Darken1);
                });

                row.AutoItem().Column(right =>
                {
                    right.Item().AlignRight().Text($"#{ShortOrderId(order.Id)}").FontSize(11).Bold();
                    right.Item().AlignRight().Text(order.OrderDate.ToString("dd MMM yyyy")).FontSize(8).FontColor(Colors.Grey.Darken1);
                    right.Item().AlignRight().Text(order.Source.ToString()).FontSize(8).FontColor(Colors.Grey.Darken1);
                });
            });

            column.Item().PaddingTop(8).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
        });
    }

    private static void ComposeCustomerInfo(IContainer container, Order order)
    {
        var address = order.ShippingAddress;

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text("Bill To").Bold().FontSize(9);
                column.Item().Text(address.FullName).FontSize(8);
                column.Item().Text(order.BuyerEmail).FontSize(8).FontColor(Colors.Grey.Darken1);
                column.Item().Text(address.PhoneNumber).FontSize(8).FontColor(Colors.Grey.Darken1);
                column.Item().Text(FormatAddress(address)).FontSize(8).FontColor(Colors.Grey.Darken1);
            });

            row.RelativeItem().AlignRight().Column(column =>
            {
                column.Item().Text("Order Info").Bold().FontSize(9);
                column.Item().Text($"Status: {order.Status}").FontSize(8);
                column.Item().Text($"Payment: {order.PaymentMethod.ToString().ToUpper()}").FontSize(8);
                column.Item().Text($"Delivery: {order.DeliveryMethod?.ShortName ?? "N/A"}").FontSize(8);
            });
        });
    }

    private static void ComposeItemsTable(IContainer container, Order order)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn(3);
                columns.RelativeColumn(2);
                columns.ConstantColumn(25);
                columns.ConstantColumn(50);
                columns.ConstantColumn(55);
            });

            table.Header(header =>
            {
                header.Cell().Element(HeaderCellStyle).Text("Product");
                header.Cell().Element(HeaderCellStyle).Text("Variant");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Qty");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Price");
                header.Cell().Element(HeaderCellStyle).AlignRight().Text("Amount");
            });

            foreach (var item in order.OrderItems)
            {
                var amount = item.Price * item.Quantity;

                table.Cell().Element(BodyCellStyle).Text(item.ItemOrdered.ProductName).FontSize(8);
                table.Cell().Element(BodyCellStyle).Text(item.ItemOrdered.VariantName).FontSize(8).FontColor(Colors.Grey.Darken1);
                table.Cell().Element(BodyCellStyle).AlignRight().Text(item.Quantity.ToString()).FontSize(8);
                table.Cell().Element(BodyCellStyle).AlignRight().Text(FormatCurrency(item.Price)).FontSize(8);
                table.Cell().Element(BodyCellStyle).AlignRight().Text(FormatCurrency(amount)).FontSize(8);
            }
        });
    }

    private static void ComposeTotals(IContainer container, decimal subtotal, decimal deliveryPrice, decimal total)
    {
        container.Column(column =>
        {
            column.Spacing(4);
            ComposeTotalRow(column, "Subtotal", subtotal);
            ComposeTotalRow(column, "Delivery", deliveryPrice);
            column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
            column.Item().Row(row =>
            {
                row.RelativeItem().Text("Total").Bold();
                row.AutoItem().Text(FormatCurrency(total)).Bold();
            });
        });
    }

    private static void ComposeTotalRow(ColumnDescriptor column, string label, decimal value)
    {
        column.Item().Row(row =>
        {
            row.RelativeItem().Text(label).FontSize(8).FontColor(Colors.Grey.Darken1);
            row.AutoItem().Text(FormatCurrency(value)).FontSize(8);
        });
    }

    private static IContainer HeaderCellStyle(IContainer container)
    {
        return container
            .Background(Colors.Grey.Lighten3)
            .BorderBottom(1)
            .BorderColor(Colors.Grey.Lighten1)
            .PaddingVertical(5)
            .PaddingHorizontal(4);
    }

    private static IContainer BodyCellStyle(IContainer container)
    {
        return container
            .BorderBottom(1)
            .BorderColor(Colors.Grey.Lighten3)
            .PaddingVertical(5)
            .PaddingHorizontal(4);
    }

    private static string FormatCurrency(decimal value)
    {
        return value.ToString("C", CurrencyCulture);
    }

    private static string ShortOrderId(Guid id)
    {
        return id.ToString()[..8].ToUpperInvariant();
    }

    private static string FormatAddress(ShippingAddress address)
    {
        var parts = new[]
        {
            address.Line1,
            address.Line2,
            address.City,
            address.State,
            address.ZipCode,
            address.Country
        };

        return string.Join(", ", parts.Where(part => !string.IsNullOrWhiteSpace(part)));
    }
}
