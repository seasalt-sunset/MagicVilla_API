using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO.User;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        public bool IsExistingUser(string username);
        public Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
        public Task<UserDTO> Registration(RegistrationRequestDTO registrationRequest);
        public Task<string> GenerateAndSaveRefreshTokenAsync(ApplicationUser user);
        public Task<TokenResponseDTO> RefreshTokens(RefreshTokenRequestDTO request);
        public Task<UserDTO> ValidateRefreshToken(string userId, string refreshToken);



    }
}