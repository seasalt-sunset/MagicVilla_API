using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MagicVilla_VillaAPI.Repository.IRepository;
using System.Net;
using MagicVilla_VillaAPI.Models.DTO.VillaPack;
using MagicVilla_VillaAPI.Models.DTO.VillaNumberPack;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _dbVilla;
        private readonly IVillaNumberRepository _dbVillaNumbers;
        protected APIResponse _response;
        public VillaAPIController(ILogger<VillaAPIController> logger, IMapper mapper, IVillaRepository dbVilla, IVillaNumberRepository dbVillaNumbers)
        {
            _logger = logger;
            _mapper = mapper;
            _dbVilla = dbVilla;
            _dbVillaNumbers = dbVillaNumbers;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VillaDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                _logger.LogInformation("Getting all Villas");
                List<Villa> allVillas = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(allVillas);
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

        [HttpGet("number")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VillaNumberDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                _logger.LogInformation("Getting all villa numbers");
                List<VillaNumber> allNumbers = await _dbVillaNumbers.GetAllAsync();
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

        [HttpGet("{id:int}", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                if (id == 0)
                {
                    _logger.LogError("Get Villa Error with Id " + id);
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(v => v.Id == id);
                if (villa is null)
                {
                    _logger.LogError($"Villa with Id {id} not found");
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _logger.LogInformation($"Get villa from Id {id}");
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
        }
        [HttpGet("number/{id:int}", Name = "GetVillaNumberById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaNumberDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVilla(VillaCreateDTO villaCreateDTO)
        {
            try
            {
                if (villaCreateDTO is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Villa villa = _mapper.Map<Villa>(villaCreateDTO);
                villa.CreatedDate = DateTime.Now.ToUniversalTime();
                await _dbVilla.CreateAsync(villa);
                _response.Result = villa;
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetVillaById", new { Id = villa.Id }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }

        }

        [HttpPost("number")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VillaNumberCreateDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                VillaNumber createVillaNumber = _mapper.Map<VillaNumber>(villaNumberCreateDTO);
                createVillaNumber.CreatedDate = DateTime.Now.ToUniversalTime();
                await _dbVillaNumbers.CreateAsync(createVillaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = createVillaNumber;
                return CreatedAtRoute("GetVillaNumberById", new { VillaNo = createVillaNumber.VillaNo }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync(v => v.Id == id);
                if (villa == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbVilla.DeleteAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("number/{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updatedVilla)
        {
            try
            {
                if (updatedVilla == null || id != updatedVilla.Id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Villa villa = _mapper.Map<Villa>(updatedVilla);
                await _dbVilla.UpdateAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPut("number/{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updatedVillaNumberDTO)
        {
            if (updatedVillaNumberDTO == null || id != updatedVillaNumberDTO.VillaNo)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            VillaNumber villaNumber = _mapper.Map<VillaNumber>(updatedVillaNumberDTO);
            await _dbVillaNumbers.UpdateAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO is null || id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync((v => v.Id == id), false);
                if (villa == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
                patchDTO.ApplyTo(villaDTO, ModelState);
                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                Villa updatedVilla = _mapper.Map<Villa>(villaDTO);
                await _dbVilla.UpdateAsync(updatedVilla);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPatch("number/{id:int}", Name = "UpdatePartialVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
