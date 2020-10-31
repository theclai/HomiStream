using System;
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
    public class ContextFixture : IDisposable
    {
        public HomiStreamsContextMock homiStreamsContextMock;

        public ContextFixture()
        {
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
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ContextFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (homiStreamsContextMock != null)
                {
                    homiStreamsContextMock.Dispose();
                    homiStreamsContextMock = null;
                }
            }
        }
    }
}
