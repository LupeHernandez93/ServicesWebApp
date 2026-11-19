using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class StatusNotificationRepository : SupplierAppRepositoryBase<StatusNotification>, IStatusNotificationRepository
    {
        public SupplierAppRepositoryContext _repositoryContext { get; set; }
        public StatusNotificationRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

    }
}
