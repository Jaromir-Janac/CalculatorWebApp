using Microsoft.EntityFrameworkCore;
using CalculatorApp.Models;

namespace CalculatorApp.Data
{
    public class CalculatorDbContext : DbContext
    {

        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
        : base(options)
        {
        }

        public DbSet<CalculatorModel> Results { get; set; } = default!;
    }
}
