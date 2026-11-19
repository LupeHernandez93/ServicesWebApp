using ServicesWebApp.Entities.PortalWebApp;

namespace ServicesWebApp.Interfaces.PortalWebApp
{
    public interface IPersonRepository: IRepositoryBase<Person>
    {
        public Task<vtPerson> GetPersonAsync(int idPerson);

        public Task<List<vtPerson>> GetAllAsync();
    }
}
