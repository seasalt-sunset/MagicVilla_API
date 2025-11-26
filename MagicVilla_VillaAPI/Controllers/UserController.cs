using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO.User;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/UserAuth")]
    [ApiVersionNeutral]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private APIResponse _response;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _response = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            var responseLogin = await _userRepo.Login(loginRequest);
            if(responseLogin == null || string.IsNullOrEmpty(responseLogin.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Incorrect username and/or password");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = responseLogin;
            return Ok(_response);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegistrationRequestDTO registrationRequest)
        {
            bool existsUsername = _userRepo.IsExistingUser(registrationRequest.UserName);

            if (existsUsername)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists!");
                return BadRequest(_response);
            }
            UserDTO newUser = await _userRepo.Registration(registrationRequest);
            if(newUser is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering!");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = newUser;
            return Ok(_response);
        }

        [HttpPost("refresh-Token")]
        [Consumes("application/json")]
        public async Task<ActionResult<APIResponse>> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            TokenResponseDTO refreshToken = await _userRepo.RefreshTokens(request);
            if(refreshToken is null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Invalid userId or refresh token!");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = refreshToken;
            return Ok(_response);

        }
    }
}
