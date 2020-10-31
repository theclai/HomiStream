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
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movieList = _movieService.GetAll();

            return Ok(movieList);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            MovieDto movieDto = _movieService.GetMovie(id);

            if (movieDto == null)
                return BadRequest("Movie not found!");

            return Ok(movieDto);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDto movieDto)
        {
            MovieDto movieDtoObj = _movieService.AddMovie(movieDto);

            if (movieDtoObj == null)
                return BadRequest("Failed to add movie!");

            return Ok(movieDtoObj);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            MovieDto movieDtoObj = _movieService.DeleteMovie(id);

            if (movieDtoObj == null)
                return BadRequest("Failed to delete movie!");

            return Ok(movieDtoObj);
        }
    }
}
