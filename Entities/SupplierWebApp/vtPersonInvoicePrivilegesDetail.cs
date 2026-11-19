namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtPersonInvoicePrivilegesDetail
    {
        public int IdPerson { get; set; }
        public string PersonFullname { get; set; }
        public int IdSupplier { get; set; }
        public string SupplierName { get; set; }
        public string SupplierRFC { get; set; }
        public string? Nickname { get; set; }
        public bool AllowUploadInvoiceWithoutOC { get; set; }
        public bool AllowUploadInvoiceSupportFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
