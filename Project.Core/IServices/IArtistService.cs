using Project.Core.DTO;
using Project.Core.Models;
using Project.Core.MyCustomAttr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.IServices
{
    [MajidAttribute]
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDTO>> GetAllArtists();
        Task<ArtistDTO> GetArtistById(int id);
        Task<ArtistDTO> CreateArtist(SaveArtistDTO newArtist);
        Task<ArtistDTO> UpdateArtist(ArtistDTO artistToBeUpdated, SaveArtistDTO artist);
        Task DeleteArtist(ArtistDTO artist);
    }
}
