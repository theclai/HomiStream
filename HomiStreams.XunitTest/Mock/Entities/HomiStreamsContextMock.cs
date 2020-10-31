using System;
using HomiStreams.Core;
using HomiStreams.Dtos;
using HomiStreams.Models;
using HomiStreams.Services;
using HomiStreams.Controllers;
using HomiStreams;
using Microsoft.EntityFrameworkCore;

namespace HomiStreams.XunitTest.Mock.Entities
{
    public class HomiStreamsContextMock : HomiStreamsDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * At this stage, a copy of the actual database is created as a memory database.
             * You do not need to create a separate test database.
             */
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
    }
}
