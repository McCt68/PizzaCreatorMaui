using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{    

    // Denne klasse representerer en session med databasen.
    // Al tilgang til databasen går gennem en instance af denne klasse.
    public class ApplicationDbContext: DbContext
    {

        // Her bruger jeg et parameter fra base klassen til at konfigure instanser af denne derived klasse -
        // Jeg bruger så at sige stadig denne derived klasses constructor -
        // men jeg bruger samtidig det parameter der hedder options fra base klassens constructor.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {            
        }        

        // DbSet typen representer basiccaly en db tabel. So her opretter jeg en Db Tabel med Navnet Toppings
        // Der egetlig er en table af Topping. Hver række i tabbelen er således en Topping
        public DbSet<Topping> Toppings { get; set; }


        // Fluent API - Konfigurere mine Tabeller. Her er det kun Toppings tabbelen -
        // siden det er den eneste tabel jeg har.
        // Her kan jeg f.eks konfigure primary / secondary key's, sætte relationer, omdøbe tabel navne -
        // eller lave regler for type konverteringer.
        // Jeg kan gøre noget af det samme med Data annotation's eller bruge begge dele samtidig -
        // Husk blot at Fluent Api, der vil have højere prioritet.        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Topping>()
                .Property(t => t.ToppingImage)
                .HasConversion<ColorToInt32Converter>();                           
        }        
    }
}
