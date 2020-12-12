using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Core.MyCustomAttr;
using Project.Core.IServices;
using Project.Core.DTO;
using Project.Api.Validators;
using Microsoft.AspNetCore.Authorization;

namespace Project.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    [Authorize]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
        {
            var music = await _musicService.GetAllWithArtist();
            return Ok(music);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            return Ok(music);
        }

        [HttpPost("")]
        public async Task<ActionResult<MusicDTO>> CreateMusic([FromBody] SaveMusicDTO saveMusicDTO)
        {
            var validator = new SaveMusicDTOValidator();
            var validatorResult = await validator.ValidateAsync(saveMusicDTO);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);

            var musicDTO = await _musicService.CreateMusic(saveMusicDTO);
            return Ok(musicDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicDTO>> UpdateMusic(int id, [FromBody] SaveMusicDTO saveMusicDTO)
        {
            var validator = new SaveMusicDTOValidator();
            var validatorResult = await validator.ValidateAsync(saveMusicDTO);
            var requestIsInvalid = id == 0 || !validatorResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validatorResult.Errors);

            var musicToBeUpdate = await _musicService.GetMusicById(id);

            if (musicToBeUpdate == null)
                return NotFound();
            var updatedMusicDTO = await _musicService.UpdateMusic(musicToBeUpdate, saveMusicDTO);
            return Ok(updatedMusicDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            if (id == 0)
                return BadRequest();

            var music = await _musicService.GetMusicById(id);

            if (music == null)
                return NotFound();

            await _musicService.DeleteMusic(music);

            return NoContent();
        }

    }
}
