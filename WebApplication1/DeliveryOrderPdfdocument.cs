using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication1.Models.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using WebApplication1.Models.Domain;

namespace WebApplication1
{
    public class DeliveryOrderPdfdocument : IDocument
    {
        private readonly Deliveryheaderprintdto _dn;
        private readonly TextStyle KeyValueStyle = TextStyle.Default.FontSize(9).FontColor(Colors.Grey.Darken2);
        private readonly TextStyle HeaderStyle = TextStyle.Default.FontSize(9).SemiBold().FontColor(Colors.White);

        public DeliveryOrderPdfdocument(Deliveryheaderprintdto dn)
        {
            _dn = dn;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);

                page.Header().Element(HeaderSection);
                page.Content().Element(ContentSection);
                page.Footer().Element(FooterSection);
            });
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata
        {
            Title = $"Delivery Note {_dn.deliveryno}"
        };

        // --- 1. HEADER SECTION (MAIN HEADER SIDE BORDER FIXED) ---
        private void HeaderSection(IContainer container)
        {
            container.Column(column =>
            {
                // Company Info Block
                column.Item().PaddingBottom(10).Row(row =>
                {
                    row.RelativeItem(2.5f).Column(col =>
                    {
                        col.Item().Text(_dn.CompanyName).FontSize(12).Bold().FontColor(Colors.Blue.Darken2);
                        col.Item().Text(_dn.CompanyAddress).Style(KeyValueStyle);
                        col.Item().Text(_dn.CompanyTelFax).Style(KeyValueStyle);
                        col.Item().Text($"Email:{_dn.CompanyEmail}").Style(KeyValueStyle);
                        col.Item().Text($"TRN:{_dn.CompanyTrn}").Style(KeyValueStyle);
                    });
                    row.RelativeItem(1.5f).Column(col => col.Item().AlignRight().Height(20));
                });

                // Separator
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                // Address/Details Table
                // FIX: Apply Border(1) to the container wrapping the header table to ensure side borders are visible.
                column.Item().Border(1).BorderColor(Colors.Grey.Lighten1).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(80);
                        columns.RelativeColumn(1.3f);
                        columns.ConstantColumn(80);
                        columns.RelativeColumn(1.3f);
                        columns.ConstantColumn(90);
                        columns.RelativeColumn(1.4f);
                    });

                    var keyStyle = KeyValueStyle;
                    var boldValueStyle = KeyValueStyle.Bold();

                    // Row 1: DELIVERY NOTE Title
                    table.Cell().ColumnSpan(6)
                        .Background(Colors.Grey.Lighten4).Border(1).BorderColor(Colors.Grey.Lighten1)
                        .PaddingVertical(5).Text("DELIVERY NOTE").FontSize(14).Bold().FontColor(Colors.Blue.Darken2).AlignCenter();

                    // Row 2: Header Labels (These cells define the top border and group boundary)
                    // Note: These cells must retain Border(1) as they define the vertical group separators
                    table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten5).Padding(3).Text("Buyer Details").Bold().Style(keyStyle);
                    table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten5).Padding(3).Text("Consignee Details").Bold().Style(keyStyle);
                    table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Grey.Lighten1).Background(Colors.Grey.Lighten5).Padding(3).Text("Delivery / PO Details").Bold().Style(keyStyle);

                    // Content Rows 3-9: 
                    AddTripleKeyPair(table, "Name:", _dn.buyername, "Name:", _dn.consigneename, "Delivery Note No:", _dn.deliveryno.ToString(), keyStyle, boldValueStyle, isLastRow: false, isFirstRow: true);
                    AddTripleKeyPair(table, "Address:", _dn.buyerdeliveryaddress, "Address:", _dn.consigneeaddress, "Delivery Date:", _dn.deliverydate != DateTime.MinValue ? _dn.deliverydate.ToString("dd-MMM-yyyy") : "-", keyStyle, boldValueStyle, isLastRow: false, isFirstRow: false);
                    AddTripleKeyPair(table, "", "", "", "", "Our Ref (Job No):", _dn.jobid.ToString(), keyStyle, boldValueStyle, isLastRow: false, isFirstRow: false);
                    AddTripleKeyPair(table, "", "", "", "", "Buyer PO No:", _dn.buyerlpono, keyStyle, boldValueStyle, isLastRow: false, isFirstRow: false);
                    AddTripleKeyPair(table, "", "", "", "", "Buyer PO Date:", _dn.buyerlpodate != DateTime.MinValue ? _dn.buyerlpodate.ToString("dd-MMM-yyyy") : "-", keyStyle, boldValueStyle, isLastRow: false, isFirstRow: false);
                    AddTripleKeyPair(table, "", "", "", "", "Consignee LPO No:", _dn.consigneelpono ?? "-", keyStyle, boldValueStyle, isLastRow: false, isFirstRow: false);
                    AddTripleKeyPair(table, "", "", "", "", "Consignee LPO Date:", _dn.consigneelpodate ?? "-", keyStyle, boldValueStyle, isLastRow: true, isFirstRow: false);
                });
            });
        }

        // --- 2. CONTENT SECTION (BLUE HEADER BORDER FIXED) ---
        private void ContentSection(IContainer container)
        {
            container.PaddingTop(10).Column(column =>
            {
                column.Spacing(5);

                column.Item().PaddingBottom(5).Text("Please accept the below material as per your order reference").Style(KeyValueStyle);

                // Apply Border(1) to the entire table container to ensure all side borders are visible.
                column.Item().Border(1).BorderColor(Colors.Grey.Lighten3).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(30);
                        columns.RelativeColumn(4.0f);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(50);
                        columns.RelativeColumn(2.5f);
                    });

                    // Table Header
                    table.Header(header =>
                    {
                        // SL No
                        header.Cell().Element(cellContainer =>
                        {
                            // FIX: Added Border(1) to the cell container for the blue header row
                            cellContainer.Background(Colors.Blue.Darken2).Border(1).BorderColor(Colors.White)
                                         .PaddingVertical(3).PaddingHorizontal(5)
                                         .AlignMiddle().AlignLeft()
                                         .Text("SL No")
                                         .Style(HeaderStyle);
                        });

                        // Description
                        header.Cell().Element(cellContainer =>
                        {
                            // FIX: Added Border(1) to the cell container for the blue header row
                            cellContainer.Background(Colors.Blue.Darken2).Border(1).BorderColor(Colors.White)
                                         .PaddingVertical(3).PaddingHorizontal(5)
                                         .AlignMiddle().AlignLeft()
                                         .Text("Description")
                                         .Style(HeaderStyle);
                        });

                        // UOM
                        header.Cell().Element(cellContainer =>
                        {
                            // FIX: Added Border(1) to the cell container for the blue header row
                            cellContainer.Background(Colors.Blue.Darken2).Border(1).BorderColor(Colors.White)
                                         .PaddingVertical(3).PaddingHorizontal(5)
                                         .AlignMiddle().AlignLeft()
                                         .Text("UOM")
                                         .Style(HeaderStyle);
                        });

                        // Qty
                        header.Cell().Element(cellContainer =>
                        {
                            // FIX: Added Border(1) to the cell container for the blue header row
                            cellContainer.Background(Colors.Blue.Darken2).Border(1).BorderColor(Colors.White)
                                         .PaddingVertical(3).PaddingHorizontal(5)
                                         .AlignMiddle().AlignRight()
                                         .Text("Qty")
                                         .Style(HeaderStyle);
                        });

                        // Remarks
                        header.Cell().Element(cellContainer =>
                        {
                            // FIX: Added Border(1) to the cell container for the blue header row
                            cellContainer.Background(Colors.Blue.Darken2).Border(1).BorderColor(Colors.White)
                                         .PaddingVertical(3).PaddingHorizontal(5)
                                         .AlignMiddle().AlignLeft()
                                         .Text("Remarks")
                                         .Style(HeaderStyle);
                        });
                    });

                    // Table Rows (retains full border for grid lines)
                    foreach (var item in _dn.LineItems.OrderBy(x => x.counter))
                    {
                        string slNo = item.srno ?? item.counter.ToString();
                        string quantityValue = decimal.TryParse(item.qty, out decimal quantity)
                            ? quantity.ToString("F2")
                            : item.qty ?? "-";

                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5).AlignLeft().Text(slNo).Style(KeyValueStyle);
                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5).AlignLeft().Text(item.description ?? "-").Style(KeyValueStyle);
                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5).AlignLeft().Text(item.uom ?? "-").Style(KeyValueStyle);
                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5).AlignRight().Text(quantityValue).Style(KeyValueStyle);
                        table.Cell().Border(1).BorderColor(Colors.Grey.Lighten3).PaddingVertical(3).PaddingHorizontal(5).AlignLeft().Text(item.remarks ?? "-").Style(KeyValueStyle);
                    }
                });

                column.Item().Height(20);

                column.Item().Text("The above goods are received in good order and condition").Style(KeyValueStyle).Italic();
            });
        }

        // --- 3. FOOTER SECTION ---
        private void FooterSection(IContainer container)
        {
            container.PaddingTop(30).Column(column =>
            {
                column.Spacing(10);

                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                column.Item().Row(row =>
                {
                    // Left Column: Received By/Vehicle Details
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().PaddingBottom(2).Text($"Received By:").Style(KeyValueStyle.Bold());
                        col.Item().PaddingBottom(10).Text(_dn.receivedby ?? "-").Style(KeyValueStyle);
                        col.Item().PaddingBottom(30).Text("Signature:").Style(KeyValueStyle.Bold());

                        col.Item().PaddingBottom(2).Text($"Vehicle No:").Style(KeyValueStyle.Bold());
                        col.Item().Text(_dn.vehicleno ?? "-").Style(KeyValueStyle);
                    });

                    // Right Column: Delivered By/Approval
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().PaddingBottom(2).Text($"Delivered By:").Style(KeyValueStyle.Bold());
                        col.Item().PaddingBottom(10).Text(_dn.deliveredby ?? "-").Style(KeyValueStyle);
                        col.Item().PaddingBottom(30).Text("Signature:").Style(KeyValueStyle.Bold());

                        col.Item().PaddingBottom(2).Text("Approved By:").Style(KeyValueStyle.Bold());
                        col.Item().Text("FOR ACE CRANES AND ENGG FZ-LLC").Style(KeyValueStyle.Bold());
                    });
                });
            });
        }

        // --- HELPER METHOD TO RENDER 6 CELLS ACROSS A ROW ---
        private void AddTripleKeyPair(TableDescriptor table,
                              string key1, string value1,
                              string key2, string value2,
                              string key3, string value3,
                              TextStyle keyS, TextStyle valueS,
                              bool isLastRow, bool isFirstRow)
        {
            var actualValueStyle = valueS;
            var borderColor = Colors.Grey.Lighten1;

            Action<IContainer> Cell(string text, TextStyle style, int columnPosition) => container =>
            {
                var cellContainer = container;

                // Apply Top border only if it is the first content row
                if (isFirstRow)
                    cellContainer = cellContainer.BorderTop(1).BorderColor(borderColor);

                // Apply Bottom border only if it is the last content row
                if (isLastRow)
                    cellContainer = cellContainer.BorderBottom(1).BorderColor(borderColor);

                // Apply Vertical Group Separator Borders (after Col 2 and Col 4)
                if (columnPosition == 2 || columnPosition == 4)
                {
                    cellContainer = cellContainer.BorderRight(1).BorderColor(borderColor);
                }

                // Content placement
                cellContainer.PaddingVertical(2).PaddingLeft(5).PaddingRight(5).AlignLeft()
                    .Text(text ?? "-").Style(style);
            };

            // Row construction, passing column position (1 to 6)
            table.Cell().Element(Cell(key1, keyS, 1));
            table.Cell().Element(Cell(value1, actualValueStyle, 2)); // Vertical border after this column (End of Buyer)

            table.Cell().Element(Cell(key2, keyS, 3));
            table.Cell().Element(Cell(value2, actualValueStyle, 4)); // Vertical border after this column (End of Consignee)

            table.Cell().Element(Cell(key3, keyS, 5));
            table.Cell().Element(Cell(value3, actualValueStyle, 6)); // End of Delivery/PO (Table Edge)
        }
    }
}