using Microsoft.EntityFrameworkCore;
using vsapro.Domain.Entities;

namespace vsapro.Infrastructure.DatabaseAccess
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
