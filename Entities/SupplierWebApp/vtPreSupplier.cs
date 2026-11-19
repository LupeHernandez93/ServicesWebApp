namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtPreSupplier {
        public int IdPreSupplier { get; set; }
        public int IdContact { get; set; }
        public string ContactName { get; set; }
        public string? PhoneNumberContact { get; set; }
        public string EmailContact { get; set; }
        public int IdStatus { get; set; }
        public string StatusSupplier { get; set; }
        public int IdTypeSupplier { get; set; }
        public string TypeSupplierName { get; set; }
        public string RFC { get; set; }
        public string Name { get; set; }
        public int? ExteriorNumber { get; set; }
        public int? InteriorNumber { get; set; }
        public int? IdCountry { get; set; }
        public string? CountryName { get; set; }
        public int? IdState { get; set; }
        public string? StateName { get; set; }
        public int? IdMunicipality { get; set; }
        public string? MunicipalityName { get; set; }
        public int? IdLocation { get; set; }
        public string? LocationName { get; set; }
        public string PostalCode { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SendToValidationDate { get; set; }
        public int? RequireModificationBy { get; set; }
        public string? RequireModificationFullName { get; set; }
        public DateTime? RequireModificationDate { get; set; }
        public string? RequireModificationReason { get; set; }
        public int? ValidationBy { get; set; }
        public string? ValidationFullName { get; set; }
        public DateTime? ValidationDate { get; set; }
        public string? ValidationReason { get; set; }
        public int? RejectedBy { get; set; }
        public string? RejectedFullName { get; set; }
        public DateTime? RejectedDate { get; set; }
        public string? RejectedReason { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
