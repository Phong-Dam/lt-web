using Microsoft.EntityFrameworkCore;

namespace DoAN_WEB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // modelBuilder.Entity<Song>().HasData(
            //     new Song { Id = 1, Artist = "Artist Name", Title = "Song Title", Link = "https://example.com/song", Views = 0 }
            // );
        }
    }
} 