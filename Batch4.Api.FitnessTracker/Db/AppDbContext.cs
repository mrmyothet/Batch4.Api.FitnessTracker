using Batch4.FitnessTracker.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.FitnessTracker.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tbl_User> tblUser { get; set; }
    }
}
