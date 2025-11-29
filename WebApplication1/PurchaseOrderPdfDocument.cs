using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication1.Models.DTO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApplication1
{
    public class PurchaseOrderPdfDocument : IDocument
    {
        private readonly PoHeaderPrintDto _po;
        private readonly TextStyle KeyValueStyle = TextStyle.Default.FontSize(9).FontColor(Colors.Grey.Darken2);
        private const float HairlineThickness = 0.25f;
        private static readonly string HairlineColor = Colors.Grey.Lighten3;

        public PurchaseOrderPdfDocument(PoHeaderPrintDto po)
        {
            _po = po;
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata
        {
            Title = $"Purchase Order {_po.Orderid}"
        };

        public DocumentSettings GetSettings() => new DocumentSettings();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);

                page.Header().Element(HeaderSection);

                page.Content().Column(column =>
                {
                    column.Spacing(15);
                    column.Item().PaddingTop(30).Element(LineItemsSection);

                    // Totals, Notes, and Annexures are now all structured within this section
                    column.Item().Element(TotalsAndNotesSection);
                });

                page.Footer().Element(FooterSection);
            });
        }

        private void HeaderSection(IContainer container)
        {
            container.Column(column =>
            {
                // --- Top Section: Company Info (Left) and PO BOX Info (Right) ---
                column.Item().PaddingBottom(10).Row(row =>
                {
                    // Left Side: Company Name and Address
                    row.RelativeItem(2.5f).Column(col =>
                    {
                        col.Item().Text(_po.CompanyName).FontSize(12).Bold().FontColor(Colors.Blue.Darken2);
                        col.Item().Text(_po.CompanyAddress).Style(KeyValueStyle);
                        col.Item().Text(_po.CompanyTelFax).Style(KeyValueStyle);
                        col.Item().Text($"Email:{_po.CompanyEmail}").Style(KeyValueStyle);
                        col.Item().Text($"TRN:{_po.CompanyTrn}").Style(KeyValueStyle);
                    });

                    // Right Side: Company Logo/Space and Company PO Box Info
                    row.RelativeItem(1.5f).Column(col =>
                    {
                        col.Item().AlignRight().Height(20); // Placeholder for logo/space

                        col.Item().AlignRight().Column(poBoxCol =>
                        {
                            poBoxCol.Spacing(2);
                        });
                    });
                });

                // Horizontal line separator
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                // --- Main PO Details, Vendor Info, and Terms in a single Table structure ---
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        // PO Details Left Column
                        columns.ConstantColumn(80); // C1: P.O. No, P.O. Date, Job No... (Keys)
                        columns.RelativeColumn(1);  // C2: P.O. No Value, P.O. Date Value... (Values)

                        // Vendor Details Middle Column
                        columns.ConstantColumn(80); // C3: Vendor, Address, Contact... (Keys)
                        columns.RelativeColumn(1.2f); // C4: Vendor Value, Address Value... (Values)

                        // Delivery & Quality Terms Right Column
                        columns.ConstantColumn(90); // C5: IncoTerms, Delivery Date... (Keys)
                        columns.RelativeColumn(1);  // C6: IncoTerms Value, Delivery Date Value... (Values)
                    });

                    // Row 1: PURCHASE ORDER Title (spans all columns)
                    table.Cell().ColumnSpan(6)
                        .Background(Colors.Grey.Lighten4)
                        .Border(1)
                        .BorderColor(Colors.Grey.Lighten1)
                        .PaddingVertical(5)
                        .Text("PURCHASE ORDER").FontSize(14).Bold().FontColor(Colors.Blue.Darken2).AlignCenter();

                    // Define common styles
                    var keyStyle = KeyValueStyle;
                    var boldValueStyle = KeyValueStyle.Bold();

                    // --- R2: P.O. No, Vendor Name, Inco Terms --- (Left Border on C1, Right Border on C6)
                    AddKeyPair(table, "P.O. No:", $"LPO#{_po.Orderid} Rev - {_po.revno}", keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Vendor:", _po.SupplierName, keyStyle, boldValueStyle);
                    AddKeyPair(table, "IncoTerms 2020:", _po.incoterms, keyStyle, boldValueStyle, null, borderRight: true);

                    // --- R3: P.O. Date, Address, Delivery Date ---
                    AddKeyPair(table, "P.O. Date:", _po.Podate.ToString("dd MMM yyyy"), keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Address:", _po.poaddress, keyStyle, keyStyle);
                    AddKeyPair(table, "Delivery Date:", _po.deliverydate?.ToString("dd MMM yyyy") ?? "N/A", keyStyle, boldValueStyle, null, borderRight: true);

                    // --- R4: Job No, Contact, Delivery Location ---
                    AddKeyPair(table, "Job No:", _po.Jobid.ToString(), keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Contact:", _po.SupplierContactName, keyStyle, boldValueStyle);
                    AddKeyPair(table, "Delivery Location:", "_po.DeliveryLocation", keyStyle, boldValueStyle, null, borderRight: true);

                    // --- R5: Currency, Phone, MTC Required ---
                    AddKeyPair(table, "Currency:", _po.pocurrency, keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Phone:", _po.SupplierTelFax, keyStyle, boldValueStyle);
                    AddKeyPair(table, "MTC Required:", _po.mtcrequired, keyStyle, boldValueStyle, _po.mtcrequired == "Yes" ? Colors.Red.Darken1 : Colors.Green.Darken1, borderRight: true);

                    // --- R6: Payment Terms, Email, COO Required ---
                    AddKeyPair(table, "Payment Terms:", _po.PaymentTermsFull, keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Email:", _po.SupplierEmail, keyStyle, boldValueStyle);
                    AddKeyPair(table, "COO Required:", _po.coorequired, keyStyle, boldValueStyle, _po.coorequired == "Yes" ? Colors.Red.Darken1 : Colors.Green.Darken1, borderRight: true);

                    // --- R7: Buyer, Supplier TRN No, Pre Dispatch Inspn ---
                    AddKeyPair(table, "Buyer:", _po.Buyer, keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, "Supplier TRN No:", _po.SupplierTrnNo, keyStyle, boldValueStyle);
                    AddKeyPair(table, "Pre Dispatch Inspn:", _po.predispatchinspection, keyStyle, boldValueStyle, _po.predispatchinspection == "Yes" ? Colors.Red.Darken1 : Colors.Green.Darken1, borderRight: true);

                    // --- R8: Vendor Ref, Empty, Warranty ---
                    AddKeyPair(table, "Vendor Ref:", _po.VendorRef, keyStyle, boldValueStyle, null, borderLeft: true);
                    AddKeyPair(table, string.Empty, string.Empty, keyStyle, keyStyle); // Empty C3, C4
                    AddKeyPair(table, "Warranty:", _po.Warranty, keyStyle, boldValueStyle, _po.Warranty == "Yes" ? Colors.Green.Darken1 : Colors.Red.Darken1, borderRight: true);

                    // --- R9: Qtn Date, Empty, Empty ---
                    AddKeyPair(table, "Qtn Date:", _po.QtnDate, keyStyle, boldValueStyle, null, borderLeft: true, isLastRow: true);
                    AddKeyPair(table, string.Empty, string.Empty, keyStyle, keyStyle, null, isLastRow: true); // Empty C3, C4
                    AddKeyPair(table, string.Empty, string.Empty, keyStyle, keyStyle, null, borderRight: true, isLastRow: true); // Empty C5, C6
                });
            });
        }

        // ---------------------- 2. LINE ITEMS ----------------------
        private void LineItemsSection(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);  // No
                    columns.RelativeColumn(1);   // ItemCode
                    columns.RelativeColumn(3);   // Item Description
                    columns.ConstantColumn(50);  // Uom
                    columns.ConstantColumn(60);  // Qty
                    columns.ConstantColumn(70);  // Unit Price
                    columns.ConstantColumn(80);  // Amount
                });

                TextStyle headerStyle = TextStyle.Default.Bold().FontSize(8).FontColor(Colors.White);
                const float CellPadding = 3;

                table.Header(header =>
                {
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).Text("#").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).Text("ItemCode").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).Text("Item Description").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).Text("Uom").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).AlignRight().Text("Qty").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).AlignRight().Text("Unit Price").Style(headerStyle);
                    header.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Background(Colors.Blue.Darken2).Padding(CellPadding).AlignRight().Text("Amount").Style(headerStyle);
                });

                TextStyle bodyStyle = TextStyle.Default.FontSize(8);

                foreach (var item in _po.LineItems)
                {
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).Text(item.No.ToString()).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).Text(item.ItemCode).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).Text(item.ItemDescription).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).Text(item.Uom).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).AlignRight().Text(item.Qty.ToString("0.000")).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).AlignRight().Text(item.UnitPrice.ToString("0.0000")).Style(bodyStyle);
                    table.Cell().Border(HairlineThickness).BorderColor(HairlineColor).Padding(CellPadding).AlignRight().Text(item.Amount.ToString("0.00")).Style(bodyStyle);
                }
            });
        }

        // ---------------------- 3. MODIFIED TOTALS AND NOTES SECTION ----------------------
        private void TotalsAndNotesSection(IContainer container)
        {
            // Define the list of possible annexures
            var requiredAnnexures = new List<string>
            {
                "Your Qtn",
                "Shipping Details",
                "Approved Drawing",
                "Others"
            };

            // Prepare the actual annexure data for easy lookup
            var selectedAnnexures = _po.Annexures
                .Select(a => a.TrimStart('•', '*', ' ').Trim())
                .ToHashSet();

            container.Column(mainCol =>
            {
                mainCol.Spacing(10);

                // ITEM 1: Financial Totals Table (Aligned Right)
                mainCol.Item().AlignRight().Table(table =>
                {
                    // C1 is for the accompanying left-text (VAT note / Amount in Words) - Relative width
                    // C2 is for the Key (e.g., "Grand Total:") - Constant width
                    // C3 is for the Value (e.g., "123.45") - Constant width
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1.5f);
                        columns.ConstantColumn(100);
                        columns.ConstantColumn(70);
                    });

                    // 1. Sub Total
                    AddTotalsRowAligned(table, "", "Sub Total:", _po.SubTotal, Colors.Black, isBold: false);

                    // 2. Discount
                    AddTotalsRowAligned(table, "", "Discount:", _po.Discount, Colors.Black, isBold: false);

                    // 3. Tax Amount (5% VAT text and Tax Amount aligned)
                    AddTotalsRowAligned(table, "(5% VAT as per UAE Law)", "Tax Amount (5%):", _po.TaxAmount, Colors.Black, isBold: false);

                    // 4. Spacer row (visual separation before Grand Total)
                    table.Cell().ColumnSpan(3).PaddingTop(5).Text(string.Empty);

                    // 5. Grand Total (Amount in words and Grand Total aligned)
                    string words = $"AED {NumberToWords((long)_po.GrandTotal)} and {((int)((_po.GrandTotal - Math.Floor(_po.GrandTotal)) * 100)):0} / 100 Only";
                    AddTotalsRowAligned(table, words, "Grand Total:", _po.GrandTotal, Colors.Red.Darken2, isBold: true, isBordered: true);
                });

                // ITEM 2: Notes and Annexures (Full Width)
                mainCol.Item().PaddingTop(15).Column(col =>
                {
                    col.Spacing(5);
                    col.Item().Text("Note to Supplier:").FontSize(10).Bold();
                    col.Item().Text($"Remarks: {_po.Remarks}").Style(KeyValueStyle);

                    col.Item().PaddingTop(5).Text("Annexure:").FontSize(10).Bold();

                    // --- Annexure Display (Single Line) ---
                    col.Item().PaddingTop(5).Row(annexRow =>
                    {
                        annexRow.Spacing(10);

                        foreach (var requiredAnnexure in requiredAnnexures)
                        {
                            bool isSelected = selectedAnnexures.Contains(requiredAnnexure);
                            string symbol = isSelected ? "✅" : "❌";

                            annexRow.AutoItem().Row(r =>
                            {
                                // Display format: * Your Qtn ✅
                                r.AutoItem().Text($"* {requiredAnnexure}").Style(KeyValueStyle).FontColor(Colors.Black);
                                r.ConstantItem(15).AlignRight().Text(symbol).FontSize(10);
                            });
                        }
                    });
                });

                // ITEM 3: Free Zone Notes (Full Width, Moved from Footer)
                mainCol.Item().PaddingTop(15).Element(FreeZoneNotesSection);
            });
        }

        // ---------------------- NEW: FREE ZONE NOTES SECTION (Used here now) ----------------------
        private void FreeZoneNotesSection(IContainer container)
        {
            // Text pulled from source files
            container.Column(col =>
            {
                col.Item().PaddingBottom(5).Text(text =>
                {
                    text.Span("For Free Zone Documentation contact our PRO - ").Style(KeyValueStyle);
                    text.Span("Mr. Ramachandran 0529058626").Style(KeyValueStyle).Bold();
                    text.Span("/").Style(KeyValueStyle);
                    text.Span("Mr. Ajith Kumar +971 52 905 7927").Style(KeyValueStyle).Bold();
                });

                col.Item().Text(text =>
                {
                    text.Span("For Free Zone Customs Clearance - Send us your Invoice & Packing List/Delivery Order strictly with Item wise 'HS Code / Country of Origin/Net & Gr Weight' by email: ").Style(KeyValueStyle);
                    text.Span("aceraklogistics@ace-me.com").Style(KeyValueStyle).Bold().FontColor(Colors.Blue.Darken2);
                });
            });
        }


        // ---------------------- 4. FOOTER (Now simplified) ----------------------
        private void FooterSection(IContainer container)
        {
            container.Column(col =>
            {
                // Horizontal line separator
                col.Item().PaddingBottom(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                // 1. Authorization Details (Aligned Right)
                col.Item().AlignRight().Column(authCol =>
                {
                    authCol.Item().Text($"Authorized Date: {_po.authorizeddate?.ToString("dd MMM yyyy") ?? "N/A"}").FontSize(8);
                    authCol.Item().Text($"Authorized By: {_po.authorizedby}").FontSize(8);
                });

                // 2. Computer Generated PO Note (Aligned Center)
                col.Item().PaddingTop(10).AlignCenter().Text("This is a computer-generated PO, hence no signature and stamp required.").FontSize(8).Italic();
            });
        }

        // ---------------------- HELPER METHODS ----------------------

        private void AddKeyPair(TableDescriptor table, string key, string value, TextStyle keyS, TextStyle valueS, string valueColor = null, bool borderLeft = false, bool borderRight = false, bool isLastRow = false)
        {
            string actualValueColor = valueColor ?? Colors.Black;
            TextStyle actualValueStyle = valueS;
            if (valueColor != null)
            {
                actualValueStyle = actualValueStyle.FontColor(actualValueColor);
            }

            var borderColor = Colors.Grey.Lighten1;

            // Key Cell (C1, C3, or C5) - Left Aligned
            table.Cell()
                .BorderTop(1)
                .BorderLeft(borderLeft ? 1 : 0) // Only Left border on C1 of each row
                .BorderBottom(isLastRow ? 1 : 0)
                .BorderColor(borderColor)
                .PaddingVertical(2)
                .PaddingLeft(5)
                .PaddingRight(5)
                .Element(container => container.AlignLeft().Text(key).Style(keyS));

            // Value Cell (C2, C4, or C6) - Left Aligned
            table.Cell()
                .BorderTop(1)
                .BorderRight(borderRight ? 1 : 0) // Only Right border on C6 of each row
                .BorderBottom(isLastRow ? 1 : 0)
                .BorderColor(borderColor)
                .PaddingVertical(2)
                .PaddingLeft(5)
                .PaddingRight(5)
                .Element(container => container.AlignLeft().Text(value).Style(actualValueStyle));
        }

        // NEW HELPER: For aligned totals (left text, key, value)
        private void AddTotalsRowAligned(TableDescriptor table, string leftText, string key, decimal value, string valueColor, bool isBold, bool isBordered = false)
        {
            var baseKeyStyle = TextStyle.Default.FontSize(10).FontColor(Colors.Grey.Darken3);
            var baseValueStyle = TextStyle.Default.FontSize(10).FontColor(valueColor);

            TextStyle keyStyle = isBold ? baseKeyStyle.Bold() : baseKeyStyle;
            TextStyle valueStyle = isBold ? baseValueStyle.Bold() : baseValueStyle;

            // Logic to determine left-text style (VAT is smaller/italic, Amount in Words is bold)
            var leftTextStyle = TextStyle.Default.FontColor(Colors.Black);
            if (key.Contains("Tax Amount"))
            {
                leftTextStyle = leftTextStyle.FontSize(8).Italic().LineHeight(1.0f); // Added LineHeight to prevent vertical wrapping issues
            }
            else if (isBold)
            {
                leftTextStyle = leftTextStyle.FontSize(10).Bold();
            }
            else
            {
                leftTextStyle = leftTextStyle.FontSize(10);
            }

            var borderColor = Colors.Red.Darken2;
            float borderWidth = isBordered ? 1 : 0;
            float padding = isBordered ? 2 : 0;

            // C1: Left Text (Amount in Words or VAT Note)
            table.Cell().Element(container =>
            {
                IContainer styledContainer = container.PaddingVertical(padding).AlignLeft();
                if (isBordered)
                {
                    styledContainer = styledContainer
                        .BorderTop(borderWidth)
                        .BorderBottom(borderWidth)
                        .BorderColor(borderColor);
                }

                styledContainer.Text(leftText).Style(leftTextStyle);
            });

            // C2: Key
            table.Cell().Element(container =>
            {
                IContainer styledContainer = container.PaddingVertical(padding).AlignRight();
                if (isBordered)
                {
                    styledContainer = styledContainer
                        .BorderTop(borderWidth)
                        .BorderBottom(borderWidth)
                        .BorderColor(borderColor);
                }

                styledContainer.Text(key).Style(keyStyle);
            });

            // C3: Value
            table.Cell().Element(container =>
            {
                IContainer styledContainer = container.PaddingVertical(padding).AlignRight();
                if (isBordered)
                {
                    styledContainer = styledContainer
                        .BorderTop(borderWidth)
                        .BorderBottom(borderWidth)
                        .BorderColor(borderColor);
                }

                styledContainer.Text(value.ToString("N2")).Style(valueStyle);
            });
        }

        private string NumberToWords(long number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }

    }
}