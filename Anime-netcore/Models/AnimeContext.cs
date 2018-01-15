using System;
using Microsoft.EntityFrameworkCore;

namespace Animenetcore.Models
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
        {
        }

        public DbSet<Anime> Animes { get; set; }
    }
}
