namespace MagicVilla_VillaAPI.Models.DTO.User
{
    public class TokenResponseDTO
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}
