using System.Linq.Expressions;

namespace TicketingSystem.Application.Abstractions.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<T> GetByAny(Expression<Func<T, bool>> expression);
        public Task<List<T>> GetByAnyList(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> GetAll();
        public Task<bool> Delete(Expression<Func<T, bool>> expression);
        public Task<T> Update(T entity);
    }
}
