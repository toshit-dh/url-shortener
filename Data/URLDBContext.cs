using Microsoft.EntityFrameworkCore;
using URLShortener.Models;

namespace URLShortener.Data
{
    public class URLDBContext : DbContext
    {
        public URLDBContext(DbContextOptions<URLDBContext> options) : base(options) { }

        public DbSet<URLMapping> UrlMappings { get; set; }
    }
}
