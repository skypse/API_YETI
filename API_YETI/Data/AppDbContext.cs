using Microsoft.EntityFrameworkCore;
using API_YETI.Models;

namespace API_YETI.Data
{
    public class AppDbContext : DbContext
    {
        // recebendo configs do DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // "Users" no BD sendo mapeada
        public DbSet<User> Users { get; set; }
    }
}
