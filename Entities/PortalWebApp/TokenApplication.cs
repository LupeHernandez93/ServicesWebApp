namespace ServicesWebApp.Entities.PortalWebApp {
    public partial class TokenApplication
    {
        public int IdToken {  get; set; }
        public int IdApplication { get; set; }
        public string? Description { get; set; } 
        public string? Token { get; set; }
        public string? DescriptionApplicationExternal { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        
        public int? CreatedBy { get; set; }
        public bool? Status { get; set; }
  
    }
}
