using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HomiStreams.Models;

namespace HomiStreams.Core
{
    public class HomiStreamsDbContext : DbContext
    {
        public HomiStreamsDbContext()
        {
        }

        public HomiStreamsDbContext(DbContextOptions<HomiStreamsDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=db4free.net;port=3306;user=corexunit;password=corexunit1234;database=corexunit;old guids=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Genre>(entity =>
            //{
            //    entity.ToTable("Genre", "Genre");

            //    entity.HasIndex(e => e.Id)
            //        .HasName("Id_UNIQUE")
            //        .IsUnique();

            //    entity.Property(e => e.Id).HasColumnType("int(11)");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //});
        }
    }
}
