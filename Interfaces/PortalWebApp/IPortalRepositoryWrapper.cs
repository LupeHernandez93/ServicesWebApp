using ServicesWebApp.Entities.PortalWebApp;

namespace ServicesWebApp.Interfaces.PortalWebApp {
    public interface IPortalRepositoryWrapper
    {
        IApplicationRepository Application { get; }
        ITokenApplicationRepository TokenApplication { get; }
        IPersonApplicationRepository PersonApplication { get; }
        IPersonRepository Person { get; }
        IPositionRepository Position { get; }
        IBusinessUnitRepository BusinessUnit { get; }
        IBranchCompanyRepository BranchCompany { get; }
        IDepartmentRepository Department { get; }
        void Save();
    }
}
