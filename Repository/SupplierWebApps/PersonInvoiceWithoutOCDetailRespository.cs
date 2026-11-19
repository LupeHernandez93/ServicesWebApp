using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class PersonInvoiceWithoutOCDetailRespository : SupplierAppRepositoryBase<PersonInvoicePrivilegesDetail>, IPersonInvoicePrivilegesDetailRepository
    {
        public SupplierAppRepositoryContext _repositoryContext { get; set; }
        public PersonInvoiceWithoutOCDetailRespository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<vtPersonInvoicePrivilegesDetail> GetCustomAsync(int idPerson, int idSupplier)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtPersonInvoicePrivilegesDetails.SingleOrDefaultAsync(x => x.IdPerson == idPerson && x.IdSupplier == idSupplier);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public async Task<List<vtPersonInvoicePrivilegesDetail>> GetAllCustomAsync(int idPerson)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtPersonInvoicePrivilegesDetails.Where(x => x.IdPerson == idPerson).OrderBy(x=>x.SupplierName).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
