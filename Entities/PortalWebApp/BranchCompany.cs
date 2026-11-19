namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class BranchCompany
    {       
        public int IdBranchCompany { get; set; }
        public int? IdCompany { get; set; }
        public string? RFC { get; set; }
        public string Name { get; set; }
        public string? Nickname { get; set; }
        public bool? isDefault { get; set; }
        public bool Status { get; set; }
        public Guid? Guid { get; set; }

    }
}
