using ServicesWebApp.Entities.SupplierWebApp;
//using ServicesWebApp.Helpers.SupplierWebApp.Notification;

namespace ServicesWebApp.Interfaces.SupplierWebApp
{
    public interface INotificationRepository: IRepositoryBase<Notification>
    {
        //public Task<vtNotification> GetView(int idNotification);
        //public Task<Notification> SendAsync(int idNotification, int idParentNotification, int idTypeAccount, int idPriority, List<int> to, string subject, string message, bool requireResponse, List<IFormFile> attachments, int idPerson);
        //public Task<TrayNotification> SearchAsync(List<int> idStatus, List<int> idPriorities, List<int> idPersons, string description, DateTime startRange, DateTime endRange, Enumerators.TypeAccount typeAccount, int idPerson);
        //public Task<List<Entities.SupplierWebApp.vtNotification>> GetAllUnread(Enumerators.TypeAccount typeAccount, int idPerson);
    }
}
