namespace ServicesWebApp.Models.SupplierWebApp
{
    public class DtTypeSupplier
    {
        public int IdTypeSupplier { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }

        public List<DtCatDocument> Documents = new List<DtCatDocument>() { };
    }
}
