namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtPersonInvoicePrivileges
    {
        public int IdPerson { get; set; }
        public string FullName { get; set; }
        public string? DepartmentName { get; set; }
        public string? PositionName { get; set; }
        public string? BusinessUnitName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string PersonCreatedBy { get; set; }
        public bool Status { get; set; }
    }
}
