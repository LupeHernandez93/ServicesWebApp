namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtToNotification
    {
        public int IdNotification { get; set; }
        public int IdPerson { get; set; }
        public int IdStatus { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int? IdSupplier { get; set; }
        public int IdTypeAccount { get; set; }
        public string TypeAccountName { get; set; }
        public string? PersonFullName { get; set; }
        public string? Email { get; set; }
        public string RFC { get; set; }
        public string SupplierName { get; set; }
    }
}
