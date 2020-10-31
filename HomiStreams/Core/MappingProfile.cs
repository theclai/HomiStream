using System;
using AutoMapper;
using HomiStreams.Dtos;
using HomiStreams.Models;

namespace HomiStreams.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<Movie, MovieDto>();
        }
    }
}
