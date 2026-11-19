using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class CatPriorityRepository : SupplierAppRepositoryBase<CatPriority>, ICatPriority
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public CatPriorityRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

    }
}
