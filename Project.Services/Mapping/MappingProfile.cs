using AutoMapper;
using Project.Core.DTO;
using Project.Core.Models;

namespace Project.Services.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Music, MusicDTO>();
            CreateMap<Music, SaveMusicDTO>();
            CreateMap<MusicDTO, SaveMusicDTO>();
            CreateMap<Artist, ArtistDTO>();

            CreateMap<MusicDTO, Music>();
            CreateMap<SaveMusicDTO, Music>();
            CreateMap<SaveMusicDTO, MusicDTO>();
            CreateMap<ArtistDTO, Artist>();
            CreateMap<SaveArtistDTO, Artist>();
        }
    }
}
