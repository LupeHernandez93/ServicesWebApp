namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class DocumentSupplier {
        public int IdDocumentSupplier { get; set; }
        public int IdDocument { get; set; }
        public int IdPreSupplier { get; set; }
        public int? IdSupplier { get; set; }
        public int IdStatus { get; set; }
        public string FileName { get; set; } = string.Empty;
        public double Length { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? ValidationBy { get; set; }
        public DateTime? ValidationDate { get; set; }
        public int? ModifiedRequestBy { get; set; }
        public DateTime? ModifiedRequestDate { get; set; }
        public string? ModifiedRequestReason { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDate { get;set; }
        public string? RejectedReason { get; set; }
        public int Version { get; set; }
    }
}
