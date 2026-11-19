using ServicesWebApp.Entities.SupplierWebApp;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ServicesWebApp.Interfaces;

namespace ServicesWebApp.Repository.SupplierWebApps
{
    public abstract class SupplierAppRepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SupplierAppRepositoryContext RepositoryContext { get; set; }
        public SupplierAppRepositoryBase(SupplierAppRepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>  RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
