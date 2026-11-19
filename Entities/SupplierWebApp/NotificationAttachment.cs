namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class NotificationAttachment
    {
        public int IdAttachment { get; set; }
        public int IdNotification { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public double Length { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AttachedBy { get; set; }
    }
}
