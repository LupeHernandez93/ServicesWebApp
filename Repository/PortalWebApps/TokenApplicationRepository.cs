using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;

namespace ServicesWebApp.Repository.PortalWebApp {
    public class TokenApplicationRepository : RepositoryBase<TokenApplication>, ITokenApplicationRepository
    {
        public TokenApplicationRepository(PortalRepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

    }
}
