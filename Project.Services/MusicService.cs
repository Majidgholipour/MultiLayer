using AutoMapper;
using Project.Core;
using Project.Core.Models;
using Project.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.DTO;

namespace Project.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public MusicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.uow = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<MusicDTO> CreateMusic(SaveMusicDTO saveMusicDTO)
        {

            var musicToCreate = _mapper.Map<SaveMusicDTO, Music>(saveMusicDTO);

            await uow.Musics.AddAsync(musicToCreate);
            await uow.CommitAsync();

            var music = await GetMusicById(musicToCreate.Id);
            return music;

        }

        public async Task DeleteMusic(MusicDTO music)
        {
            var NewMusic = _mapper.Map<MusicDTO, Music>(music);
            uow.Musics.Remove(NewMusic);
            await uow.CommitAsync();
        }

        public async Task<IEnumerable<MusicDTO>> GetAllWithArtist()
        {
            var music = await uow.Musics.GetAllWithArtistAsync();
            return _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(music);
        }

        public async Task<MusicDTO> GetMusicById(int id)
        {
            var music = await uow.Musics.GetWithArtistByIdAsync(id);
            return _mapper.Map<Music, MusicDTO>(music);

        }

        public async Task<IEnumerable<MusicDTO>> GetMusicsByArtistId(int artistId)
        {
            var mu = await uow.Musics.GetAllWithArtistByArtistIdAsync(artistId);
            return _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(mu);

        }

        public async Task<MusicDTO> UpdateMusic(MusicDTO musicToBeUpdated, SaveMusicDTO music)
        {
            var newmusic = _mapper.Map<SaveMusicDTO, Music>(music);
            var newmusicBacis = _mapper.Map<MusicDTO, Music>(musicToBeUpdated);
            newmusicBacis.Name = newmusic.Name;
            newmusicBacis.ArtistId = newmusic.ArtistId;
            await uow.CommitAsync();
            var updatedMusic = await GetMusicById(newmusic.Id);
            return updatedMusic;
        }

      
    }
}
