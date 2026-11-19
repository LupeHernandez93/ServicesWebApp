namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class ValidationSupplier {
        public int IdValidationSupplier { get; set; }
        public int IdPreSupplier { get; set; }
        public int IdValidation { get; set; }
        public int IdStatus { get; set; }
        public int IdPerson { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set;}
    }
}
