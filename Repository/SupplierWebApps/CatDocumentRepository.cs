using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class CatDocumentRepository : SupplierAppRepositoryBase<CatDocument>, ICatDocumentRepository {
        public CatDocumentRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
        }
    }
}
