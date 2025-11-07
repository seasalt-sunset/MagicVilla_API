using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>
            {
                new VillaDTO{Id = 1, Name= "Pool View", SqrMeters = 300, Occupancy = 4},
                new VillaDTO{Id = 2, Name= "Beach View", SqrMeters = 1000, Occupancy = 2}
            };
    }
}
