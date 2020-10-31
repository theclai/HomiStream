using System;
using HomiStreams.Dtos;
using System.Collections.Generic;

namespace HomiStreams.Services
{
    public interface IMovieService
    {
        List<MovieDto> GetAll();

        MovieDto GetMovie(int id);

        MovieDto AddMovie(MovieDto movie);

        MovieDto DeleteMovie(int id);
    }
}
