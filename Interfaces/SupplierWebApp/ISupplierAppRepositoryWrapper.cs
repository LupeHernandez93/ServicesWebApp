
namespace ServicesWebApp.Interfaces.SupplierWebApp
{
    public interface ISupplierAppRepositoryWrapper
    {
        ICatDocumentRepository CatDocument { get; }
        IContactRepository Contact { get; }
        IConfigurationRepository Configuration { get; }
        ICompanySupplierRepository CompanySupplier { get; }
        ICatPriority CatPriority { get; }
        ITypeSupplierRepository TypeSupplier { get; }
        ISupplierRepository Supplier { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceAttachmentRepository InvoiceAttachment { get; }
        IInvoiceAttachmentPPDRepository InvoiceAttachmentPPD { get; }
        IPreInvoiceRepository PreInvoice { get; }
        IPreSupplierRepository PreSupplier { get; }
        IPersonInvoicePrivilegesRepository PersonInvoicePrivileges { get; }
        IPersonInvoicePrivilegesDetailRepository PersonInvoicePrivilegesDetail { get; }
        IDocumentRepository Document { get; }
        IDocumentSupplierRepository DocumentSupplier { get; }
        INotificationRepository Notification { get; }
        INotificationAttachmentRepository NotificationAttachment { get; }
        INotificationResponsibleRepository NotificationResponsible { get; }
        IToNotificationRepository ToNotification { get; }
        IStatusInvoiceRepository StatusInvoice { get; }
        IStatusNotificationRepository StatusNotification { get; }

        void Save();
    }
}
