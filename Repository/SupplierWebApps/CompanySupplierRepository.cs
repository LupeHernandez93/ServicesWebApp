using ServicesWebApp.Entities.SupplierWebApp;
using ServicesWebApp.Interfaces.SupplierWebApp;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public class CompanySupplierRepository : SupplierAppRepositoryBase<CompanySupplier>, ICompanySupplierRepository {
        private SupplierAppRepositoryContext _repositoryContext;
        public CompanySupplierRepository(SupplierAppRepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        //public List<Supplier> GetSuppliers(int idCompany, List<int> idBranchCompanies, List<int> idBusinessUnits)
        //{
        //    try
        //    {
        //        List<int> supplierList = _repositoryContext.CompanySuppliers
        //            .Where(x => 
        //                x.IdCompany == idCompany && 
        //                (idBranchCompanies.First() != 0 ? idBranchCompanies .Contains(x.IdBranchCompany): true) && 
        //                (idBusinessUnits.First() != 0 ? idBusinessUnits.Contains(x.IdBusinessUnit): true)
        //             )
        //            .Select(x => x.IdSupplier)
        //            .Distinct()
        //            .ToList();

        //        List<Supplier> suppliers = _repositoryContext.Suppliers.Where(x => supplierList.Contains(x.IdSupplier)).OrderBy(x => x.Name).ToList();

        //        return suppliers;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
