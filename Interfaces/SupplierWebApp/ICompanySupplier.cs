using ServicesWebApp.Entities.SupplierWebApp;

namespace ServicesWebApp.Interfaces.SupplierWebApp
{
    public interface ICompanySupplierRepository : IRepositoryBase<CompanySupplier>
    {
        //public List<Supplier> GetSuppliers(int idCompany, List<int> idBranchCompanies, List<int> idBusinessUnits);
    }
}
