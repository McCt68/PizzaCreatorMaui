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
            modelBuilder.Entity<Topping>()
                .Property(t => t.ToppingImage)
                .HasConversion<ColorToInt32Converter>();            
        }
    }
}
