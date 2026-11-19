namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class ToNotification
    {
        public int IdNotification { get; set; }
        public int IdPerson { get; set; }
        public int IdStatus { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? ArchivedDate { get; set;}
        public DateTime? ResponseDate { get; set; }
    }
}
