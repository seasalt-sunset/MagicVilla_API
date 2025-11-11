using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private ILogger<VillaAPIController> _logger;
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogger<VillaAPIController> logger, AppDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VillaDTO>))]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Getting all Villas");
            List<Villa> allVillas = await _db.Villas.ToListAsync();
            List<VillaDTO> allVillaDTOs = _mapper.Map<List<VillaDTO>>(allVillas);
            return Ok(allVillaDTOs);
        }

        [HttpGet("{id:int}", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (id == 0)
            {
                _logger.LogError("Get Villa Error with Id " + id);
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa is null)
            {
                return NotFound();
            }
            VillaDTO villaDTO = _mapper.Map<VillaDTO>(villa);
            return Ok(villaDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaCreateDTO>> CreateVilla(VillaCreateDTO villaCreateDTO)
        {
            if (villaCreateDTO is null)
            {
                return BadRequest(villaCreateDTO);
            }

            Villa villa = _mapper.Map<Villa>(villaCreateDTO);
            villa.CreatedDate = DateTime.Now.ToUniversalTime();
            await _db.Villas.AddAsync(villa);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVillaById", new { Id = villa.Id }, villa);

        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updatedVilla)
        {
            if (updatedVilla == null || id != updatedVilla.Id)
            {
                return BadRequest();
            }

            Villa villa = _mapper.Map<Villa>(updatedVilla);
            _db.Update(villa);
            await _db.SaveChangesAsync();
            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
            patchDTO.ApplyTo(villaDTO, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa updatedVilla = _mapper.Map<Villa>(villa);
            _db.Update(updatedVilla);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
