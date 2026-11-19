using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class TypeSupplierRepository : SupplierAppRepositoryBase<CatTypeSupplier>, ITypeSupplierRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public TypeSupplierRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }
    }
}
