using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Validators;
using Project.Core.DTO;
using Project.Core.IServices;

namespace Project.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "test,test1")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _ArtistService;
        public ArtistController(IArtistService artistService)
        {
            this._ArtistService = artistService;
        }
        [Authorize(Roles = "test")]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtists()
        {
            var artist = await _ArtistService.GetAllArtists();
            return Ok(artist);
        }
        [Authorize(Roles = "test1")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            var artist = await _ArtistService.GetArtistById(id);
            return Ok(artist);
        }
        [HttpPost("")]
        public async Task<ActionResult<ArtistDTO>> CreateArtist([FromBody] SaveArtistDTO saveArtistDTO)
        {
            var validator = new SaveArtistDTOValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistDTO);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var artist = await _ArtistService.CreateArtist(saveArtistDTO);
            return Ok(artist);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistDTO>> UpdateArtist(int id,[FromBody] SaveArtistDTO saveArtistDTO)
        {
            var validator = new SaveArtistDTOValidator();
            var validatorResult = await validator.ValidateAsync(saveArtistDTO);

            var requestIsValid = id == 0 || !validatorResult.IsValid;
            if (requestIsValid)
                return BadRequest(validatorResult.Errors);

            var artistToBeUpdate = await _ArtistService.GetArtistById(id);

            if (artistToBeUpdate == null)
                return NotFound();
            var updatedMusicDTO = await _ArtistService.UpdateArtist(artistToBeUpdate, saveArtistDTO);
            return Ok(updatedMusicDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> del (int id)
        {
            if (id == 0)
                return BadRequest();

            var Artist = await _ArtistService.GetArtistById(id);

            if (Artist == null)
                return NotFound();

            await _ArtistService.DeleteArtist(Artist);

            return NoContent();
        }
    }
}
