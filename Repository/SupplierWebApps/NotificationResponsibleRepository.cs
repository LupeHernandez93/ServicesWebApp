using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class NotificationResponsibleRepository : SupplierAppRepositoryBase<NotificationResponsible>, INotificationResponsibleRepository
    {
        private SupplierAppRepositoryContext _repositoryContext { get; set; }
        public NotificationResponsibleRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<List<vtNotificationResponsible>> GetAllCustomAsync()
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtNofiticationResponsibles.Where(x=>x.Status == true).OrderBy(x=>x.DepartmentName).ThenBy(x=>x.Name).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}
    }
}
