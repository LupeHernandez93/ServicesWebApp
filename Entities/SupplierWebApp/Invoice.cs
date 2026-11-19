using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.Xml.Linq;

namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class Invoice
    {
        public int IdInvoice { get; set; }
        public int? IdPreInvoice { get; set; }
        public int IdPerson { get; set; }
        public int IdCompany { get; set; }
        public int IdBranchCompany { get; set; }
        public int IdBusinessUnit { get; set; }
        public int IdStatus { get; set; }
        public string UUID { get; set; } = string.Empty;
        public string? Folio { get; set; }
        public string? Serie { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TransferredTax { get; set; }
        public decimal? RetainedTax { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; } = string.Empty;
        public decimal? ExchangeRate { get; set; }
        public string IdReceiptType { get; set; } = string.Empty;
        public string IdPaymentMethod { get; set; } = string.Empty;
        public string? IdFormPayment { get; set; }
        public string? PaymentTerms { get; set; }
        public string? IdExport { get; set; }
        public string? PlaceExpedition { get; set; }
        public string Emitter_RFC { get; set; } = string.Empty;
        public string Emitter_Name { get; set; } = string.Empty;
        public string? Emitter_IdFiscalRegime { get; set; }
        public string Receptor_RFC { get; set; } = string.Empty;
        public string Receptor_Name { get; set; } = string.Empty;
        public string? Receptor_TaxDomicile { get; set; }
        public string? Receptor_IdFiscalRegime { get; set; } 
        public string? Receptor_IdUseCFDI { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? PurchaseOrder { get; set; }
        public string? ReceptionOrder { get; set; }
        public string? JSONPurchaseOrder { get; set; }
        public string? Comments { get; set; }
        public string? XML_FileName { get; set; }
        public string? XML_OriginalFileName { get; set; }
        public double? XML_Length { get; set; }
        public string? XML_Path { get; set; }
        public XElement? XML_Content { get; set; }
        public string? PDF_FileName { get; set; }
        public double? PDF_Length { get; set; }
        public string? PDF_Path { get; set; }
        public DateTime? PDF_CreatedDate { get; set; }
        public string? SUPPORT_FileName { get; set; }
        public double? SUPPORT_Length { get; set; }
        public string? SUPPORT_Path { get; set; }
        public DateTime? SUPPORT_CreatedDate { get; set; }
        public int? StoppedBy { get; set; }
        public DateTime? StoppedDate { get; set; }
        public string? StoppedReason { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovedReason { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDate { get; set; }
        public string? RejectedReason { get; set; }
        public int? CanceledBy { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string? CanceledReason { get; set; }
        public int? PaidBy { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaidReason { get; set; }
        public string? PaidCEPFileXML { get; set; }
        public string? PaidCEPFilePDF { get; set; }
        public int? REPBy { get; set; }
        public DateTime? REPDate { get; set; }
        public string? REPFileXML { get; set; }
        public string? REPFilePDF { get; set; }
        public string? HistoryData { get; set; }
        public string Version { get; set; } = string.Empty;

    }
}
