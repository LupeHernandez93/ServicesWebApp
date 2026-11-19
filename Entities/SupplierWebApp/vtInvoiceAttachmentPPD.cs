namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtInvoiceAttachmentPPD
    {
        public int IdAttachmentPPD { get; set; }
        public int IdInvoice { get; set; }
        public int Consecutive { get; set; }
        public string? Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? AmountPaid { get; set; }
        public string Type { get; set; }
        public string? OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string? XML_Content { get; set; }
        public string Extension { get; set; }
        public double Length { get; set; }
        public string? PaidReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string TypeAccountName { get; set; }
        public string? CreatedByName { get; set; }
        public string? PositionName { get; set; }
        public string? DepartmentName { get; set; }
        public string? SupplierRFC { get; set; }
        public string? SupplierName { get; set; }
    }
}
