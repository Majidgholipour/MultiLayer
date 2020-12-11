using Project.Core;
using Project.Core.Models;
using Project.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Core.DTO;
using AutoMapper;

namespace Project.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArtistService(IUnitOfWork unitOfWork,IMapper mapper )
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ArtistDTO> CreateArtist(SaveArtistDTO newArtist)
        {
            var artistToCreate = _mapper.Map<SaveArtistDTO, Artist>(newArtist);
            await _unitOfWork.Artists.AddAsync(artistToCreate);
            await _unitOfWork.CommitAsync();

            var artist = await GetArtistById(artistToCreate.Id);
            return  artist;
        }
               

        public async Task DeleteArtist(ArtistDTO artist)
        {
            var NewMusic = _mapper.Map<ArtistDTO, Artist>(artist);
            _unitOfWork.Artists.Remove(NewMusic);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllArtists()
        {
            return _mapper.Map<IEnumerable<Artist>,IEnumerable<ArtistDTO>>(await _unitOfWork.Artists.GetAllWithMusicsAsync());
        }

        public async Task<ArtistDTO> GetArtistById(int id)
        {
            var artist = await _unitOfWork.Artists.GetWithMusicsByIdAsync(id);
            return _mapper.Map< Artist,ArtistDTO>(artist);
        }

        public async Task<ArtistDTO> UpdateArtist(ArtistDTO artistToBeUpdated, SaveArtistDTO artist)
        {
            var newArtist = _mapper.Map<SaveArtistDTO, ArtistDTO>(artist);
            var newArtistBasic = _mapper.Map<ArtistDTO, Artist>(artistToBeUpdated);

            newArtistBasic.Name = newArtist.Name;
            await _unitOfWork.CommitAsync();

            return await GetArtistById(newArtistBasic.Id);
        }

    
    }
}
