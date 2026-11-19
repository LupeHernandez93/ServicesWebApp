namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class BusinessUnit
    {
       
        public int IdBusinessUnit { get; set; }
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string? Nickname { get; set; }
        public string? Address { get; set; }
        public int? ExteriorNumber { get; set; }
        public int? InteriorNumber { get; set; }
        public int? IdCountry { get; set; }
        public int? IdState { get; set; }
        public int? IdMunicipality { get; set; }
        public int? IdLocality { get; set; }
        public int? IdColony { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Status { get; set; }
        public Guid? Guid { get; set; }
    }
}
