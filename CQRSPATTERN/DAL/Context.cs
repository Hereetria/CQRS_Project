using Microsoft.EntityFrameworkCore;

namespace CQRSPATTERN.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A7AFDHF\\SQLEXPRESS;" +
                "Initial Catalog=SignalRDB;Integrated Security=true;" +
                "TrustServerCertificate=True;");
        }
        public DbSet<Product> CQRSProducts { get; set; }
    }
}
