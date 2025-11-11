using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllVillas(Expression<Func<Villa, bool>> filter = null);

        Task<Villa> GetVilla(Expression<Func<Villa, bool>> filter = null, bool tracked = true);

        Task CreateVilla(Villa entity);

        Task UpdateVilla(Villa entity);

        Task DeleteVilla(Villa entity);

        Task Save();
    }
}
