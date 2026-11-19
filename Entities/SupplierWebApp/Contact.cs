namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class Contact {
        public int IdContact { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int IdTypeSupplier { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PwdTemp { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ExpirationDays { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime? ActivationDate { get; set; }
        public int? SendLastEmailBy { get; set; }
        public DateTime? SendLastEmailDate { get; set; }
        public bool Status { get; set; }

    }
}
