using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebCalculatorWithDI.DataBase
{
    public class ExpressionEntitysContext : DbContext
    {
        private const string catalog = "CalculatorExpressionsCache";
        private const string connectionString = $"Data Source=localhost;Initial Catalog={catalog};Integrated Security=True";

        private readonly ILoggerFactory _loggerFactory =
            LoggerFactory.Create(config => config.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }
    
        public DbSet<ExpressionEntity> Items { get; set; }
        public new void SaveChanges() => base.SaveChanges();
    }
}