namespace ServicesWebApp.Entities.SupplierWebApp {
    public partial class CatDocument {
        public int IdDocument { get; set; }
        public string Key { get; set; } = string.Empty;
        public int Order { get; set; }
        public string IdTypeSupplier { get; set; }
        public string Description { get; set;}
        public double? FileMaxLenghtMB { get; set; }
        public bool isRequired { get; set; }
        public string? Extension { get; set; }
        public bool Status { get; set; }

    }
}
