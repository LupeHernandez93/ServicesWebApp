using ServicesWebApp.Entities.PortalWebApp;
using ServicesWebApp.Interfaces.PortalWebApp;

namespace ServicesWebApp.Repository.PortalWebApp
{
    public class PortalRepositoryWrapper : IPortalRepositoryWrapper, IDisposable
    {
        private PortalRepositoryContext _repositoryContext;

        private IApplicationRepository _applicationRepository;
        private ITokenApplicationRepository _tokenapplicationRepository;
        private PersonApplicationRepository _personApplicationRepository;
        private IPersonRepository _personRepository;
        private IPositionRepository _positionRepository;
        private IBusinessUnitRepository _businessUnitRepository;
        private IBranchCompanyRepository _branchCompanyRepository;
        private IDepartmentRepository _departmentRepository;

        public PortalRepositoryWrapper(PortalRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IApplicationRepository Application
        {
            get
            {
                if (_applicationRepository == null)
                {
                    _applicationRepository = new ApplicationRepository(_repositoryContext);
                }
                return _applicationRepository;
            }
        }

        public ITokenApplicationRepository TokenApplication
        {
            get
            {
                if (_tokenapplicationRepository == null)
                {
                    _tokenapplicationRepository = new TokenApplicationRepository(_repositoryContext);
                }
                return _tokenapplicationRepository;
            }
        }



        public IPersonApplicationRepository PersonApplication
        {
            get
            {
                if (_personApplicationRepository == null)
                {
                    _personApplicationRepository = new PersonApplicationRepository(_repositoryContext);
                }
                return _personApplicationRepository;
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(_repositoryContext);
                }
                return _personRepository;
            }
        }

        public IPositionRepository Position
        {
            get
            {
                if (_positionRepository == null)
                {
                    _positionRepository = new PositionRepository(_repositoryContext);
                }
                return _positionRepository;
            }
        }

        public IBusinessUnitRepository BusinessUnit
        {
            get
            {
                if (_businessUnitRepository == null)
                {
                    _businessUnitRepository = new BusinessUnitRepository(_repositoryContext);
                }
                return _businessUnitRepository;
            }
        }

        public IBranchCompanyRepository BranchCompany
        {
            get
            {
                if (_branchCompanyRepository == null)
                {
                    _branchCompanyRepository = new BranchCompanyRepository(_repositoryContext);
                }
                return _branchCompanyRepository;
            }
        }

        public IDepartmentRepository Department
        {
            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_repositoryContext);
                }
                return _departmentRepository;
            }
        }




        public void Dispose()
        {
            if (_repositoryContext != null)
            {
                _repositoryContext.Dispose();
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
