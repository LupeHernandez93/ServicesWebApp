
namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class InvoiceAttachment
    {
        public int IdAttachment { get; set; }
        public int IdInvoice { get; set; }
        public string? OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AttachedBy { get; set; }
    }
}
