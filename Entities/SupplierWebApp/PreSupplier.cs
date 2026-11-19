namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class PreSupplier
    {
        public int IdPreSupplier { get; set; }
        public int IdContact { get; set; }
        public int IdStatus { get; set; }
        public int IdTypeSupplier { get; set; }
        public string RFC { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int? ExteriorNumber { get; set; }
        public int? InteriorNumber { get; set; }
        public int? IdCountry { get; set; }
        public int? IdState { get; set; }
        public int? IdMunicipality { get; set; }
        public int? IdLocation { get; set;}
        public string PostalCode { get; set;} = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? SendToValidationDate { get; set; }
        public int? RequireModificationBy { get; set; }
        public DateTime? RequireModificationDate { get; set;}
        public string? RequireModificationReason { get; set; }
        public int? ValidationBy { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string? ValidationReason { get; set; }
        public int? RejectedBy { get; set; }
        public DateTime? RejectedDate { get;set; }
        public string? RejectedReason { get;set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
