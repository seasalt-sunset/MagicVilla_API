using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly AppDbContext _db;

        public VillaNumberRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(VillaNumber entity)
        {
            _db.Update(entity);
            await SaveAsync();
        }
    }
}
