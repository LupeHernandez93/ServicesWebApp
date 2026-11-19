using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class NotificationAttachmentRepository : SupplierAppRepositoryBase<NotificationAttachment>, INotificationAttachmentRepository
    {
        public SupplierAppRepositoryContext _repositoryContext { get; set; }
        public NotificationAttachmentRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
