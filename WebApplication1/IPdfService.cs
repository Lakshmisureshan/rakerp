using WebApplication1.Models.DTO;
using static WebApplication1.Controllers.POController;

namespace WebApplication1
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePurchaseOrderPdf(PoHeaderPrintDto po);
    }
}
