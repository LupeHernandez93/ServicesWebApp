namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtContact {
        public int IdContact { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int IdTypeSupplier { get; set; }
        public string TypeSupplierName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PwdTemp { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ExpirationDays { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? SendLastEmailDate { get; set; }
        public bool Status { get; set; }
    }
}
