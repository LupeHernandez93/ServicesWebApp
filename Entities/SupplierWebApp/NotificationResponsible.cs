namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class NotificationResponsible
    {
        public int IdPerson { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Status { get; set; }
    }
}
