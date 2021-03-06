﻿using AutoMapper;
using Project.Core.DTO;
//using Project.Api.Resources;
using Project.Core.Models;
using Project.Core.Models.Auth;

namespace Project.Api.Mapping
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

            CreateMap<UserSignUpDTO, User>().ForMember(u => u.UserName, o => o.MapFrom(u => u.Email));
        }
    }
}
