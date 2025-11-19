using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO.VillaNumberPack;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;


namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {

        private ILogger<VillaNumberAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _dbVillaNumbers;
        protected APIResponse _response;

        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger, IMapper mapper, IVillaNumberRepository dbVillaNumbers)
        {
            _logger = logger;
            _mapper = mapper;
            _dbVillaNumbers = dbVillaNumbers;
            _response = new();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VillaNumberDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ResponseCache(Duration = 30)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers([FromQuery(Name = "searchDetails")] string? search)
        {
            try
            {
                _logger.LogInformation("Getting all villa numbers");
                List<VillaNumber> allNumbers = await _dbVillaNumbers.GetAllAsync();
                if (!string.IsNullOrEmpty(search))
                {
                    allNumbers = allNumbers.Where(n => n.SpecialDetails.ToLower().Contains(search.ToLower())).ToList();
                }
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(allNumbers);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }

        }
        
        [HttpGet("number/{id:int}", Name = "GetVillaNumberById")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaNumberDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError($"Get villaNumber ERROR with Id: {id}");
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                VillaNumber villaNo = await _dbVillaNumbers.GetAsync(v => v.VillaNo == id);
                if (villaNo is null)
                {
                    _logger.LogError($"Villa with Id {id} not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _logger.LogInformation($"Get villaNumber from Id {id}");
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNo);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost("number")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VillaNumberCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber(VillaNumberCreateDTO villaNumberCreateDTO)
        {
            try
            {
                if (villaNumberCreateDTO is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);

                }
                if (await _dbVillaNumbers.GetAsync(v => v.VillaNo == villaNumberCreateDTO.VillaNo) != null)
                {
                    _logger.LogError($"Villa number {villaNumberCreateDTO.VillaNo} already exists!");
                    ModelState.AddModelError("Custom error", "VillaNo already exists!");
                    return BadRequest(ModelState);
                }
                if (await _dbVillaNumbers.GetAsync(v => v.VillaId == villaNumberCreateDTO.VillaId) == null)
                {
                    _logger.LogError($"Villa number {villaNumberCreateDTO.VillaId} invalid!");
                    ModelState.AddModelError("Custom error", "VillaId invalid!");
                    return BadRequest(ModelState);
                }
                VillaNumber createVillaNumber = _mapper.Map<VillaNumber>(villaNumberCreateDTO);
                createVillaNumber.CreatedDate = DateTime.Now.ToUniversalTime();
                await _dbVillaNumbers.CreateAsync(createVillaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = createVillaNumber;
                return CreatedAtRoute("GetVillaNumberById", new { id = villaNumberCreateDTO.VillaNo }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("number/{id:int}", Name = "DeleteVillaNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                VillaNumber villaNumber = await _dbVillaNumbers.GetAsync(v => v.VillaNo == id);
                if (villaNumber is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbVillaNumbers.DeleteAsync(villaNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPut("number/{id:int}", Name = "UpdateVillaNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updatedVillaNumberDTO)
        {
            if (updatedVillaNumberDTO == null || id != updatedVillaNumberDTO.VillaNo)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if (await _dbVillaNumbers.GetAsync(v => v.VillaId == updatedVillaNumberDTO.VillaId) == null)
            {
                _logger.LogError($"Villa number {updatedVillaNumberDTO.VillaId} invalid!");
                ModelState.AddModelError("Custom error", "VillaId invalid!");
                return BadRequest(ModelState);
            }
            VillaNumber villaNumber = _mapper.Map<VillaNumber>(updatedVillaNumberDTO);
            await _dbVillaNumbers.UpdateAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);

        }

        [HttpPatch("number/{id:int}", Name = "UpdatePartialVillaNumber")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<APIResponse>> UpdatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        {
            if (patchDTO is null || id == 0)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            VillaNumber villaNumberToPatch = await _dbVillaNumbers.GetAsync((v => v.VillaNo == id), false);
            if (villaNumberToPatch is null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            VillaNumberUpdateDTO villaNumberToPatchDTO = _mapper.Map<VillaNumberUpdateDTO>(villaNumberToPatch);
            patchDTO.ApplyTo(villaNumberToPatchDTO, ModelState);
            if (!ModelState.IsValid)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = ModelState;
                return BadRequest(_response);
            }

            VillaNumber villaNumberPatched = _mapper.Map<VillaNumber>(villaNumberToPatchDTO);
            await _dbVillaNumbers.UpdateAsync(villaNumberPatched);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }


    }
}
