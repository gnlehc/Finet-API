using Finet.Model;
using Microsoft.EntityFrameworkCore;

namespace Finet.Context
{
    public class FinetContext : DbContext
    {
        public FinetContext(DbContextOptions<FinetContext> options) : base(options)
        {

        }

        public DbSet<MsUser> MsUser { get; set; }
        public DbSet<MsExpenseCategory> MsExpenseCategory { get; set; }
        public DbSet<MsMethod> MsMethod { get; set; }
        public DbSet<TrExpense> TrExpense { get; set; }
    }
}
