namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class Department {
        public int IdDepartment { get; set; }
        public int IdCompany { get; set; }
        public string? IdCostCenter { get; set; }
        public string? Classification { get; set; }
        public string? AccountingGroup { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid? Guid { get; set; }
   
    }
}
