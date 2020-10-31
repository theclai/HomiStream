using System;
namespace HomiStreams.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public GenreDto GenreDto { get; set; }

        public double Duration { get; set; }

        public int Rating { get; set; }

        public MovieDto()
        {
        }
    }
}
