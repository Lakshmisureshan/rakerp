using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WebApplication1.Models.DTO;
using static WebApplication1.Controllers.POController;

namespace WebApplication1
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> GeneratePurchaseOrderPdf(PoHeaderPrintDto po)
        {
            var document = new PurchaseOrderPdfDocument(po);
            return document.GeneratePdf();
        }
    }
}
