using Finet.Model;
using Microsoft.EntityFrameworkCore;

namespace Finet.Context
{
    public class FinetContext : DbContext
    {
        public FinetContext(DbContextOptions<FinetContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}
