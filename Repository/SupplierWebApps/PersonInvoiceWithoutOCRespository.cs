using Microsoft.EntityFrameworkCore;
using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class PersonInvoiceWithoutOCRespository : SupplierAppRepositoryBase<PersonInvoicePrivileges>, IPersonInvoicePrivilegesRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public PersonInvoiceWithoutOCRespository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public async Task<List<vtPersonInvoicePrivileges>> GetAllCustomAsync()
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtPersonInvoicePrivileges.OrderBy(x=>x.FullName).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public async Task<vtPersonInvoicePrivileges> GetCustomAsync(int idPerson)
        //{
        //    try
        //    {
        //        return await _repositoryContext.VtPersonInvoicePrivileges.SingleOrDefaultAsync(x => x.IdPerson == idPerson);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw(ex);
        //    }
        //}
    }
}
