using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class ConfigurationRepository : SupplierAppRepositoryBase<Configuration>, IConfigurationRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public ConfigurationRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
