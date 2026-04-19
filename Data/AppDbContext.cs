using DrowingTogether.Models;
using Microsoft.EntityFrameworkCore;

namespace DrowingTogether.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Stroke> Strokes { get; set; }
        public DbSet<DrawingBoard> Boards { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
