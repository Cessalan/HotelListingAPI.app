using Microsoft.EntityFrameworkCore;

namespace HotelLising.Api.Data
{
    public class HotelListingDBContext:DbContext
    {
        public HotelListingDBContext(DbContextOptions<HotelListingDBContext> options):base(options)
        {
        
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
