using Finet.Model;
using Microsoft.EntityFrameworkCore;

namespace Finet.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
