namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class PersonInvoicePrivilegesDetail
    {
        public int IdPerson {  get; set; }
        public int IdSupplier {  get; set; }
        public bool AllowUploadInvoiceWithoutOC { get; set; }
        public bool AllowUploadInvoiceSupportFile { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
