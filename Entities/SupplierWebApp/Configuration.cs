namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public int? PrincipalIdCompany { get; set; }
        public int? DefaultIdRuleSupplier { get; set; }
        public string? DefaultIdCountry { get; set; }
        public string? DefaultCompany { get; set; }
        public string? UrlServicesWebApp { get; set; }
        public string? UrlColaboratorWebApp { get; set; }
        public int? MonthlyInvoiceDeadline { get; set; }
        public string? InvoiceDeadlineMessage { get; set; }
        public DateTime? StartDeadlineMessage { get; set; }
        public DateTime? EndDeadlineMessage { get; set; }
        public string? RolValidationSupplier { get; set; }
        public string? DebugEmail { get; set; }
    }
}
