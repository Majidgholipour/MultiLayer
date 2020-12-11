using Project.Core.DTO;
using Project.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Project.Core.IServices
{

    public interface IMusicService
    {
        Task<IEnumerable<MusicDTO>> GetAllWithArtist();
        Task<MusicDTO> GetMusicById(int id);
        Task<IEnumerable<MusicDTO>> GetMusicsByArtistId(int artistId);
        Task<MusicDTO> CreateMusic(SaveMusicDTO newMusic);
        Task<MusicDTO> UpdateMusic(MusicDTO musicToBeUpdated, SaveMusicDTO music);
        Task DeleteMusic(MusicDTO music);
    }
}
