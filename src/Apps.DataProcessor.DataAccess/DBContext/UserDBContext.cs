using Apps.DataProcessor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apps.DataProcessor.DataAccess.DBContext
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
            
        }

        internal DbSet<User> Users { get; set; }
    }
}
