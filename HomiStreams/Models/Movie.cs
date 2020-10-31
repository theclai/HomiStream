using System;
namespace HomiStreams.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public double Duration { get; set; }

        public int Rating { get; set; }

        public Movie()
        {
        }
    }
}
