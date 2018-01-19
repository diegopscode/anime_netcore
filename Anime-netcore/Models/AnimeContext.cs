using System;
using Microsoft.EntityFrameworkCore;

namespace Animenetcore.Models
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Anime>().HasMany(c => c.episodes).WithOne(e => e.anime);
        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Episode> Episdes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
