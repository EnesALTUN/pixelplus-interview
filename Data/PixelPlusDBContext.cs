using PixelPlusMulakat.Models;
using Microsoft.EntityFrameworkCore;

namespace PixelPlusMulakat.Data
{
    public class PixelPlusDBContext : DbContext
    {
        public PixelPlusDBContext(DbContextOptions<PixelPlusDBContext> options) : base(options) {}

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Article> Article { get; set; }
    }
}