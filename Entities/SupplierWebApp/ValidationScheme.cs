namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class ValidationScheme {
        public int IdValidation { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public int IdLevel { get; set; }
        public string? TypeValidation { get; set; }
        public string? IdPersons { get; set; }
        public string? IdDepartments { get; set; }
        public bool Status { get; set; }
    }
}
