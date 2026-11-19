namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class Notification
    {
        public int IdNotification { get; set; }
        public int? IdParentNotification { get; set; }
        public int IdTypeAccount { get; set; }
        public int IdStatus { get; set; }
        public int IdPriority { get; set; }
        public int? IdSupplier { get; set; }
        public int To { get; set; }
        public int From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int SentToBy { get; set; }
        public DateTime? SendToDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public bool? RequireResponse { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
