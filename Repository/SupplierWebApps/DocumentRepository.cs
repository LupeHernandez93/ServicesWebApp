using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class DocumentRepository: SupplierAppRepositoryBase<CatDocument>, IDocumentRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public DocumentRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }

    }
}
