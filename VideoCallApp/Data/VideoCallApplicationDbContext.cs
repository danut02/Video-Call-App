using Microsoft.EntityFrameworkCore;
using VideoCallApp.Models;

namespace VideoCallApp.Data
{
    public class VideoCallApplicationDbContext : DbContext
    {
        public VideoCallApplicationDbContext(DbContextOptions<VideoCallApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Name = "FemaleSexSymbol.png" },
                new Image { Id = 2, Name = "MaleSexSymbol.png" }
            );

            
            modelBuilder.Entity<Image>().HasIndex(e => e.Name).IsUnique();

            
            modelBuilder.Entity<User>()
                .HasOne(u => u.theImage)
                .WithMany(i => i.Users)
                .HasForeignKey(u => u.ImageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .IsRequired(false); 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Friends> Friends { get; set; }
    }
}
