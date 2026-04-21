using DrowingTogether.Models;
using Microsoft.EntityFrameworkCore;

namespace DrowingTogether.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Stroke> Strokes { get; set; }
        public DbSet<DrawingBoard> Boards { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>().ToTable("shapes");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
