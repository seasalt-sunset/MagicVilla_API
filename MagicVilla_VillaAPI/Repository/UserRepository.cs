using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO.User;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        private string secretKey;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext db, IConfiguration config, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public bool IsExistingUser(string username)
        {
            if (_db.ApplicationUsers.FirstOrDefault(u => u.UserName == username) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO
                {
                    Token = "",
                    User = null
                };
            }

            TokenResponseDTO allTokens = await CreateTokens(user);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = allTokens.AccessToken,
                RefreshToken = allTokens.RefreshToken,
                RefreshTokenExpireDate = user.RefreshTokenExpireDate,
                User = _mapper.Map<UserDTO>(user),
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };
            return loginResponseDTO;
        }

        public async Task<TokenResponseDTO> CreateTokens(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var roles = await _userManager.GetRolesAsync(user);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            string refreshToken = CreateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireDate = DateTime.UtcNow.AddMinutes(10);
            await _db.SaveChangesAsync();
            return new TokenResponseDTO
            {
                UserId = user.Id,
                AccessToken = tokenHandler.WriteToken(accessToken),
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = user.RefreshTokenExpireDate
            };
        }

        public async Task<UserDTO> Registration(RegistrationRequestDTO registrationRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequest.UserName,
                Name = registrationRequest.Name
            };
            await GenerateAndSaveRefreshTokenAsync(user);

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequest.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("admin"));
                        await _roleManager.CreateAsync(new IdentityRole("customer"));
                    }

                    await _userManager.AddToRoleAsync(user, "admin");

                    UserDTO userDTO = _mapper.Map<UserDTO>(_db.Users.FirstOrDefault(u => u.UserName == user.UserName));
                    return userDTO;
                }
            }
            catch (Exception e)
            {

            }

            return new UserDTO();
        }

        private string CreateRefreshToken()
        {
            var token = new byte[256];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(token);
            return Convert.ToBase64String(token);
        }

        public async Task<string> GenerateAndSaveRefreshTokenAsync(ApplicationUser user)
        {
            user.RefreshToken = CreateRefreshToken();
            user.RefreshTokenExpireDate = DateTime.UtcNow.AddMinutes(10);
            await _db.SaveChangesAsync();
            return user.RefreshToken;
        }

        public async Task<TokenResponseDTO> RefreshTokens(RefreshTokenRequestDTO request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (request.RefreshToken != user.RefreshToken || user == null)
            {
                return null;
            }

            TokenResponseDTO allTokens = await CreateTokens(user);


            return allTokens;


        }
        public async Task<UserDTO> ValidateRefreshToken(string userId, string refreshToken)
        {
            ApplicationUser user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpireDate <= DateTime.UtcNow)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}
