namespace MagicVilla_VillaAPI.Models.DTO.User
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
