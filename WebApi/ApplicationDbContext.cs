using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    // This class represents a session with the database.
    // All access to the database is done through an instance of this class 
    public class ApplicationDbContext: DbContext
    {

        // Her bruger jeg et parameter fra base klassen til at konfigure instanser af denne derived klasse -
        // Jeg bruger så at sige stadig denne derived klasses constructor -
        // men jeg bruger samtidig det parameter der hedder options fra base klassens constructor.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {            
        }

        // A DbSet type basically represents a table. So here I am creating a table named Toppings which -
        // is basically a database table of Topping, So each row in Toppings is a different Topping.
        public DbSet<Topping> Toppings { get; set; }

        // Fluent API - Konfigurere mine Tabeller. Her er det kun Toppings tabbelen -
        // siden det er den eneste tabel jeg har.
        // Her kan jeg f.eks konfigure primary / secondary key's, sætte relationer, omdøbe tabel navne -
        // eller lave regler for type konverteringer.
        // Jeg kan gøre noget af det samme med Data annotation's eller bruge begge dele samtidig -
        // Husk blot at Fluent Api, der vil have højere prioritet.        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // I don't think I should use this type of converter
            // Instead use IValue Converter from MAUI
            modelBuilder.Entity<Topping>()
                .Property(t => t.ToppingImage)
                .HasConversion<ColorToInt32Converter>();     
            
            // Maybe I can try one more time to make a converter similar to waht I am doing in the viewModel
            // When converting from HEX TO a COlor object
        }        
    }
}
