using System;
using HomiStreams.Core;
using HomiStreams.Dtos;
using HomiStreams.Models;
using HomiStreams.Services;
using HomiStreams.Controllers;
using HomiStreams;
using Xunit;
using Newtonsoft.Json;
using HomiStreams.XunitTest.Fixture;
using Microsoft.AspNetCore.Mvc;

namespace HomiStreams.XunitTest
{
    public class GenreControllerTest : IClassFixture<ControllerFixture>
    {
        private GenreController genreController;

        public GenreControllerTest(ControllerFixture fixture)
        {
            genreController = fixture.genreController;
        }

        [Fact]
        public void Get_WithoutParam_Ok_Test()
        {
            var result = genreController.Get() as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Theory]
        [InlineData(0)]
        public void GetGenre_WithNonGenre_ThenBadRequest_Test(int id)
        {
            var result = genreController.GetGenre(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Genre not found!", result.Value);
        }

        [Theory]
        [InlineData(454673)]
        public void GetGenre_WithTestData_ThenOk_Test(int id)
        {
            var result = genreController.GetGenre(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<GenreDto>(result.Value);
        }

        [Theory]
        [ClassData(typeof(GenreTheoryData))]
        public void AddGenre_WithTestData_ThenOk_Test(GenreDto genreInfo)
        {
            var result = genreController.AddGenre(genreInfo) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(genreInfo), JsonConvert.SerializeObject(result.Value));
        }

        [Theory]
        [InlineData(0)]
        public void Delete_WithNonGenre_ThenBadRequest_Test(int id)
        {
            var result = genreController.Delete(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to delete genre!", result.Value);
        }

        [Theory]
        [InlineData(685349)]
        public void Delete_WithTestData_ThenOk_Test(int id)
        {
            var result = genreController.Delete(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<GenreDto>(result.Value);
        }
    }
}
