using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class StatusInvoiceRepository: SupplierAppRepositoryBase<StatusInvoice>, IStatusInvoiceRepository {
        public StatusInvoiceRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {

        }
    }
}
