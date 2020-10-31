using System;
using System.Collections.Generic;
using HomiStreams.Dtos;

namespace HomiStreams.Services
{
    public interface IGenreService
    {
        List<GenreDto> GetAll();

        GenreDto GetGenre(int id);

        GenreDto AddGenre(GenreDto genre);

        GenreDto DeleteGenre(int id);
    }
}
