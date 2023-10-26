using Apps.DataProcessor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apps.DataProcessor.DataAccess.DBContext
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
            
        }

        public DbSet<UserRecord> Users { get; set; }
    }
}
