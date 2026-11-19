using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class ToNotificationRepository : SupplierAppRepositoryBase<ToNotification>, IToNotificationRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public ToNotificationRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<List<vtToNotification>> GetAllAsync(int idNotification)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtToNotifications.Where(x => x.IdNotification == idNotification).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}

    }
}
