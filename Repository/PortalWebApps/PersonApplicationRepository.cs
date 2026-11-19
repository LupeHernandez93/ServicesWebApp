using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;

namespace ServicesWebApp.Repository.PortalWebApp {
    public class PersonApplicationRepository : RepositoryBase<PersonApplication>, IPersonApplicationRepository {
        public PersonApplicationRepository(PortalRepositoryContext repositoryContext) : base(repositoryContext) {

        }
    }
}
