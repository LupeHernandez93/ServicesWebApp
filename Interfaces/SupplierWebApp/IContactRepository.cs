using ServicesWebApp.Entities.SupplierWebApp;
//using ServicesWebApp.Helpers.SupplierWebApp.Supplier;
using ServicesWebApp.Repository;

namespace ServicesWebApp.Interfaces.SupplierWebApp {
    public interface IContactRepository: IRepositoryBase<Contact> {
        //public Task<vtContact> GetCustomAsync(int idContact);
        //public Task<ContactTray> GetListCustomAsync(List<int> idTypeSupplier, int idStatus, string description);
        //public Task<Contact> SaveAsync(int idContact, string companyName, string contactName, string firstName, string lastName, string phoneNumber, string email, int idTypeSupplier, string username, string password, int expiredDays, bool status, int idPerson);
        //public Task<bool> SendEmailContact(int idContact, int idPerson);
    }
}
