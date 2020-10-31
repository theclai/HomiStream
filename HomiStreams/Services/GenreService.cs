using System;
using AutoMapper;
using HomiStreams.Dtos;
using HomiStreams.Core;
using HomiStreams.Models;
using System.Linq;
using System.Collections.Generic;

namespace HomiStreams.Services
{
    public class GenreService : IGenreService
    {
        private HomiStreamsDbContext _homiStreamsDbContext;
        private IMapper _mapper;

        public GenreService(HomiStreamsDbContext homiStreamsDbContext, IMapper mapper)
        {
            _homiStreamsDbContext = homiStreamsDbContext;
            _mapper = mapper;
        }

        public List<GenreDto> GetAll()
        {
            var GenreDtoList = _homiStreamsDbContext.Genres.ToList();

            return _mapper.Map<List<GenreDto>>(GenreDtoList);
        }

        public GenreDto AddGenre(GenreDto genre)
        {
            try
            {
                Genre genreObj = _mapper.Map<Genre>(genre);

                _homiStreamsDbContext.Genres.Add(genreObj);
                _homiStreamsDbContext.SaveChanges();

                return _mapper.Map<GenreDto>(genreObj);
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public GenreDto DeleteGenre(int id)
        {
            Genre genreObj = _homiStreamsDbContext.Genres.Where(w => w.Id == id).FirstOrDefault();

            if (genreObj == null)
                return null;

            _homiStreamsDbContext.Genres.Remove(genreObj);
            _homiStreamsDbContext.SaveChanges();

            return _mapper.Map<GenreDto>(genreObj);
        }

        public GenreDto GetGenre(int id)
        {
            Genre genreObj = _homiStreamsDbContext.Genres.Where(w => w.Id == id).FirstOrDefault();

            return _mapper.Map<GenreDto>(genreObj);
        }
    }
}
