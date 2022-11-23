using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalculatorWebApp.Models;

namespace CalculatorWebApp.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext (DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        public DbSet<CalculatorWebApp.Models.Calculator> Results { get; set; } = default!;
    }
}
