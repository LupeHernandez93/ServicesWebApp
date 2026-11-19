using ServicesWebApp.Entities.SupplierWebApp;
//using SupplierWebApp.Helpers;
//using SupplierWebApp.Helpers.C5SupplierApp.Supplier;
using ServicesWebApp.Interfaces.SupplierWebApp;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class SupplierRepository : SupplierAppRepositoryBase<Supplier>, ISupplierRepository
    {
        private SupplierAppRepositoryContext _repositoryContext;
        public SupplierRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext) {
            _repositoryContext = repositoryContext;
        }

        //public async Task<vtSupplier> GetSupplier(int idSupplier) {
        //    try {

        //        return await _repositoryContext.VtSuppliers.SingleOrDefaultAsync(x => x.IdSupplier == idSupplier);

        //    }
        //    catch (Exception ex) {

        //        throw (ex);
        //    }
        //}

        public async Task<List<vtSupplier>> GetAllSupplier()
        {
            try
            {
                return await _repositoryContext.VtSuppliers.Where(x => x.Status == true).OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
