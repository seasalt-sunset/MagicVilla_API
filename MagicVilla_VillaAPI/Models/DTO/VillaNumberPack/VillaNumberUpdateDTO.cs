using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO.VillaNumberPack
{
    public class VillaNumberUpdateDTO
    {
        [Key]
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
