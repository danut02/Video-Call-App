using Microsoft.EntityFrameworkCore;
using VideoCallApp.Models;

namespace VideoCallApp.Data
{
    public class VideoCallApplicationDbContext:DbContext
    {
        public VideoCallApplicationDbContext(DbContextOptions<VideoCallApplicationDbContext> options):base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Image>().HasData(new Image { Id = 1, Name = "FemaleSexSymbol.png" });
            modelBuilder.Entity<Image>().HasData(new Image { Id = 2, Name = "MaleSexSymbol.png" });
            modelBuilder.Entity<Image>().HasIndex(e => e.Name)
                .IsUnique();
            modelBuilder.Entity<User>().
                HasOne(e => e.theImage).
                WithMany(e => e.Users).
                HasForeignKey(e => e.ImageId).
                IsRequired().OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }   
    }
}
