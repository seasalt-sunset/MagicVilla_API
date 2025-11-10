using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Utilities
{
    public static class Conversions
    {
        public static VillaDTO VillaToDTO(Villa villa)
        {
            return new VillaDTO
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                SqrMeters = villa.SqrMeters,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };
        }

        public static VillaUpdateDTO VillaToDTOUpdate(Villa villa)
        {
            return new VillaUpdateDTO
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                SqrMeters = villa.SqrMeters,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };

        }

        public static Villa DTOToVilla(VillaDTO villaDTO)
        {
            return new Villa
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                SqrMeters = villaDTO.SqrMeters,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
        }

        public static Villa DTOToVillaCreate(VillaCreateDTO villaDTO)
        {
            return new Villa
            {
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                SqrMeters = villaDTO.SqrMeters,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
        }

        public static Villa DTOToVillaUpdate(VillaUpdateDTO villaDTO)
        {
            return new Villa
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                SqrMeters = villaDTO.SqrMeters,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
        }

        public static List<Villa> AllDTOsToVillas(List<VillaDTO> allVillasDTO)
        {
            List<Villa> allVillas = new List<Villa>();
            foreach(VillaDTO villaDTO in allVillasDTO)
            {
                allVillas.Add(DTOToVilla(villaDTO));
            }
            return allVillas;
        }

        public static List<Villa> AllUpdateDTOsToVillas(List<VillaUpdateDTO> allVillasDTO)
        {
            List<Villa> allVillas = new List<Villa>();
            foreach (VillaUpdateDTO villaDTO in allVillasDTO)
            {
                allVillas.Add(DTOToVillaUpdate(villaDTO));
            }
            return allVillas;
        }

        public static List<VillaDTO> AllVillasToDTOs(List<Villa> allVillas)
        {
            List<VillaDTO> allVillaDTOs = new List<VillaDTO>();
            foreach (Villa villa in allVillas)
            {
                allVillaDTOs.Add(VillaToDTO(villa));
            }
            return allVillaDTOs;
        }

        public static List<VillaUpdateDTO> AllVillasToDTOsUpdate(List<Villa> allVillas)
        {
            List<VillaUpdateDTO> allVillaDTOs = new List<VillaUpdateDTO>();
            foreach (Villa villa in allVillas)
            {
                allVillaDTOs.Add(VillaToDTOUpdate(villa));
            }
            return allVillaDTOs;
        }
    }
}
