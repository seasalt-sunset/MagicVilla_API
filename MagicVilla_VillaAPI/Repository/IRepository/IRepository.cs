using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task CreateAsync(T entity);

        public Task DeleteAsync(T entity);

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, int pageSize = 3, int pageCount = 1);

        public Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);

        public Task SaveAsync();
    }
}
