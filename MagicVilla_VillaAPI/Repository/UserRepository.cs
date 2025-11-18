using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO.User;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        private string secretKey;

        public UserRepository(AppDbContext db, IConfiguration config)
        {
            _db = db;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsExistingUser(string username)
        {
            if (_db.LocalUsers.FirstOrDefault(u => u.UserName == username) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            LocalUser user = _db.LocalUsers.FirstOrDefault(u => u.UserName == loginRequest.UserName && u.Password == loginRequest.Password);
            
            if(user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDTO;
        }

        public async Task<LocalUser> Registration(RegistrationRequestDTO registrationRequest)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registrationRequest.UserName,
                Name = registrationRequest.Name,
                Password = registrationRequest.Password,
                Role = registrationRequest.Role
            };

            await _db.LocalUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
