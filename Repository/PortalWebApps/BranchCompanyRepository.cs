using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;
using Microsoft.EntityFrameworkCore;
using Azure.Core.GeoJson;

namespace ServicesWebApp.Repository.PortalWebApp
{
    public class BranchCompanyRepository : RepositoryBase<BranchCompany>, IBranchCompanyRepository
    {
        //private PortalRepositoryContext _repositoryContext;
        public BranchCompanyRepository(PortalRepositoryContext repositoryContext) : base(repositoryContext)
        {
            /*_repositoryContext = repositoryContext;*/
        }



        //public async Task<Position> GetPositionAsync()
        //{
        //    try
        //    {
        //        return await _repositoryContext.Positions.Max(x => x.IdPosition));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
