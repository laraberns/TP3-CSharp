using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Data
{
    public class CityBreaksContext : DbContext
    {
        public CityBreaksContext(DbContextOptions<CityBreaksContext> options) : base(options) { }
        DbSet<Country> Countries { get; set; }
    }
}
