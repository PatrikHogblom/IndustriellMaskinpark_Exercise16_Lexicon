using IndustriellMaskinpark.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustriellMaskinpark.Data
{
    public class MaskinparkDbContext : DbContext
    {
        public MaskinparkDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Device> Devices { get; set; }
    }
}
