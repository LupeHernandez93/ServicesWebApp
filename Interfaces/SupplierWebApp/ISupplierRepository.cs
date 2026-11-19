using ServicesWebApp.Entities.SupplierWebApp;

namespace ServicesWebApp.Interfaces.SupplierWebApp
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        //public Task<vtSupplier> GetSupplier(int idSupplier);
        public Task<List<vtSupplier>> GetAllSupplier();
        
    }
}
