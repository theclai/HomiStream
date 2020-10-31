using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomiStreams.Core;
using HomiStreams.Dtos;
using HomiStreams.Models;
using HomiStreams.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomiStreams.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "HomiStreams", $"v{GetType().Assembly.GetName().Version.ToString()}", });
        }

        [HttpGet]
        public IActionResult Index()
        {
            var genreList = _genreService.GetAll();

            return Ok(genreList);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            GenreDto genreDto = _genreService.GetGenre(id);

            if (genreDto == null)
                return BadRequest("Genre not found!");

            return Ok(genreDto);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreDto genreDto)
        {
            GenreDto genreDtoObj = _genreService.AddGenre(genreDto);

            if (genreDtoObj == null)
                return BadRequest("Failed to add genre!");

            return Ok(genreDtoObj);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GenreDto genreDtoObj = _genreService.DeleteGenre(id);

            if (genreDtoObj == null)
                return BadRequest("Failed to delete genre!");

            return Ok(genreDtoObj);
        }
    }
}
