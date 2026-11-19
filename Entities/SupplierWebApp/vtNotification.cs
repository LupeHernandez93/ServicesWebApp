namespace ServicesWebApp.Entities.SupplierWebApp
{
    public partial class vtNotification
    {
        public int IdNotification { get; set; }
        public int? IdParentNotification { get; set; }
        public int IdTypeAccount { get; set; }
        public string TypeAccountName { get; set; }
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public int IdPriority { get; set; }
        public string PriorityName { get; set; }
        public int? IdSupplier { get; set; }
        public string? SupplierRFC { get; set; }
        public string? SupplierName { get; set; }
        public int To { get; set; }
        public string? PersonToFullName { get; set; }
        public string? PersonToPositionName { get; set; }
        public string? PersonToDepartmentName { get; set; }
        public string? PersonToEmail { get; set; }
        public int From { get; set; }
        public string? PersonFromFullName { get; set; }
        public string? PersonFromPositionName { get; set; }
        public string? PersonFromDepartmentName { get; set; }
        public string? PersonFromEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int SentToBy { get; set; }
        public string? SentToFullName { get; set; }
        public string? SentToTypeAccountName { get; set; }
        public DateTime? SendToDate { get; set; }
        public DateTime? ReadDate { get; set; }
        public DateTime? ArchivedDate { get; set; }
        public bool? RequireResponse { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
}
