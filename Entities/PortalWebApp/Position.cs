namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class Position
    {       
        public int IdPosition { get; set; }
        public int IdCompany { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Guid? Guid { get; set; }



    }
}
