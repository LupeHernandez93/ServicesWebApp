namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class Supplier
    {
        public int IdSupplier { get; set; }
        public string RFC { get; set; }
        public string Name { get; set; }
        public string? Nickname { get; set; }
        public string? Address { get; set; }
        public int? ExteriorNumber { get; set; }
        public int? InteriorNumber { get; set; }
        public int IdTypeSupplier { get; set; }
        public int? IdCountry { get; set; }
        public int? IdState { get; set; }
        public int? IdMunicipality { get; set; }
        public int? IdLocation { get; set;}
        public string? PostalCode { get; set;}
        public DateTime CreatedDate { get; set; }
        public bool IsInternal { get; set; }
        public bool? AllowUploadInvoice { get; set; }
        public bool? AllowUploadInvoiceWithoutOC { get; set; }
        public bool? AllowUploadInvoiceSupportFile { get; set; }
        public bool Status { get; set; }
    }
}
