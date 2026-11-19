namespace ServicesWebApp.Models.SupplierWebApp
{
    public class DtSupplier
    {
        public int IdSupplier { get; set; }
        public string RFC { get; set; }
        public string Name { get; set; }
        public string? Nickname { get; set; }
        public string? Address { get; set; }
        public int? ExteriorNumber { get; set; }
        public int? InteriorNumber { get; set; }
        public string? IdCountry { get; set; }
        public string? CountryName { get; set; }
        public string? StateName { get; set; }
        public string? IdMunicipality { get; set; }
        public string? MunicipalityName { get; set; }
        public int? IdLocation { get; set; }
        public string? LocationName { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? AllowUploadInvoice { get; set; }
        public bool? AllowUploadInvoiceWithoutOC { get; set; }
        public bool? AllowUploadInvoiceSupportFile { get; set; }
        public bool Status { get; set; }

        public List<DtDocumentSupplier> SupportDocuments = new List<DtDocumentSupplier>() { };
    }
}
