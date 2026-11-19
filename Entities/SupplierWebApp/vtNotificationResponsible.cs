namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtNotificationResponsible
    {
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? IdDepartment { get; set; }
        public string? DepartmentName { get; set; }
        public int? IdPosition { get; set; }
        public string? PositionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
    }
}
