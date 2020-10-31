using System;
using HomiStreams.Core;
using HomiStreams.Dtos;
using HomiStreams.Models;
using HomiStreams.Services;
using HomiStreams.Controllers;
using HomiStreams;
using Xunit;

namespace HomiStreams.XunitTest
{
    public class GenreTheoryData : TheoryData<GenreDto>
    {
        public GenreTheoryData()
        {
            Add(new GenreDto()
            {
                Id = 843545,
                Name = "Comedy",
                Description = "Story that tells about a series of funny, or comical events, intended to make the audience laugh."
            });
        }
    }
}
