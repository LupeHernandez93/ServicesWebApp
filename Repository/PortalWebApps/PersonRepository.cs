using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using Microsoft.EntityFrameworkCore;

namespace ServicesWebApp.Repository.PortalWebApp
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private PortalRepositoryContext _repositoryContext;
        public PersonRepository(PortalRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<vtPerson>> GetAllAsync()
        {
            try
            {
                return await _repositoryContext.vtPersons.Where(x=>x.Status == true && x.IsEmployeeC5M == false && (x.IdTypeAccount == 2)).OrderBy(x=>x.Name).ThenBy(x=>x.FirstName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<vtPerson> GetPersonAsync(int IdPerson)
        {
            try
            {
                return await _repositoryContext.vtPersons.SingleOrDefaultAsync(x => x.IdPerson == IdPerson && x.IsEmployeeC5M == false && (x.IdTypeAccount == 2));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
