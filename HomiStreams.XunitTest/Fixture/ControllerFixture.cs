using System;
using AutoMapper;
using HomiStreams.Core;
using HomiStreams.Dtos;
using HomiStreams.Models;
using HomiStreams.Services;
using HomiStreams.Controllers;
using HomiStreams;
using Microsoft.EntityFrameworkCore;
using HomiStreams.XunitTest.Mock.Entities;

namespace HomiStreams.XunitTest.Fixture
{
    public class ControllerFixture : IDisposable
    {
        private HomiStreamsContextMock homiStreamsContextMock { get; set; }
        private GenreService genreService { get; set; }
        private IMapper mapper { get; set; }

        public GenreController genreController { get; private set; }

        public ControllerFixture()
        {
            #region Create mock/memory database

            homiStreamsContextMock = new HomiStreamsContextMock();

            homiStreamsContextMock.Genres.AddRange(new Genre[]
            {
                new Genre
                {
                    Id = 685349,
                    Name = "Action",
                    Description = "Similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations (including explosions, fight scenes, daring escapes, etc.)"
                },
                new Genre
                {
                    Id = 454673,
                    Name = "Thriller",
                    Description = "A story that is usually a mix of fear and excitement"
                }
            });
            homiStreamsContextMock.SaveChanges();

            #endregion

            #region Mapper settings with original profiles.

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            #endregion

            // Create UserService with Memory Database
            userService = new UserService(testDbContextMock, mapper);

            // Create Controller
            userController = new UserController(userService);

        }

        #region ImplementIDisposableCorrectly
        /** https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019 */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                testDbContextMock.Dispose();
                testDbContextMock = null;

                userService = null;
                mapper = null;

                userController = null;
            }
        }
        #endregion
    }
}
