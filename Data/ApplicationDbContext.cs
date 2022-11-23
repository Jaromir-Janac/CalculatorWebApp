using CalculatorWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorWebApp.Data {
    public class ApplicationDbContext : DbContext {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CalculatorWebApp.Models.Calculator> Results { get; set; } = default;

    }
}

