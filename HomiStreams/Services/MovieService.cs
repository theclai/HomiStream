using System;
using AutoMapper;
using HomiStreams.Dtos;
using HomiStreams.Core;
using HomiStreams.Models;
using System.Linq;
using System.Collections.Generic;

namespace HomiStreams.Services
{
    public class MovieService : IMovieService
    {
        private HomiStreamsDbContext _homiStreamsDbContext;
        private IMapper _mapper;

        public MovieService(HomiStreamsDbContext homiStreamsDbContext, IMapper mapper)
        {
            _homiStreamsDbContext = homiStreamsDbContext;
            _mapper = mapper;
        }

        public List<MovieDto> GetAll()
        {
            var movieDtoList = _homiStreamsDbContext.Movies.ToList();

            return _mapper.Map<List<MovieDto>>(movieDtoList);
        }

        public MovieDto AddMovie(MovieDto movie)
        {
            try
            {
                Movie movieObj = _mapper.Map<Movie>(movie);

                _homiStreamsDbContext.Movies.Add(movieObj);
                _homiStreamsDbContext.SaveChanges();

                return _mapper.Map<MovieDto>(movieObj);
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public MovieDto DeleteMovie(int id)
        {
            Movie movieObj = _homiStreamsDbContext.Movies.Where(w => w.Id == id).FirstOrDefault();

            if (movieObj == null)
                return null;

            _homiStreamsDbContext.Movies.Remove(movieObj);
            _homiStreamsDbContext.SaveChanges();

            return _mapper.Map<MovieDto>(movieObj);
        }

        public MovieDto GetMovie(int id)
        {
            Movie movieObj = _homiStreamsDbContext.Movies.Where(w => w.Id == id).FirstOrDefault();

            return _mapper.Map<MovieDto>(movieObj);
        }
    }
}
