using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class InvoiceAttachmentRepository : SupplierAppRepositoryBase<InvoiceAttachment>, IInvoiceAttachmentRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public InvoiceAttachmentRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
