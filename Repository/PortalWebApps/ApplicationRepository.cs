using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;

namespace ServicesWebApp.Repository.PortalWebApp {
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(PortalRepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

    }
}
