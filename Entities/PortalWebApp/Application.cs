namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class Application
    {
        public int IdApplication { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public string? OfflineMessage { get; set; }

    }
}
