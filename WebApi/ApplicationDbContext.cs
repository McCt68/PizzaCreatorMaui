using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {            
        }

        // A DbSet type basically represents a table
        public DbSet<Topping> Toppings { get; set; }

        // Could use this to build the model
        // like specify primary key, modify the table name, configure table relations, and other kind of configurations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // I don't think I should use this type of converter
            // Instead use Ivalue Converter from MAUI
            modelBuilder.Entity<Topping>()
                .Property(t => t.ToppingImage)
                .HasConversion<ColorToInt32Converter>();            
        }
    }

    // prøv at rode med det her
    // System.Drawing.Color c = System.Drawing.Color.FromArgb(int);

    // int x = c.ToArgb();
}
