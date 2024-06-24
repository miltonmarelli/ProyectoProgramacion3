using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Models;

namespace Proyecto.Infraestructure.Context
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommercialInvoice> CommercialInvoices { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Valor discriminador para diferenciar entre los tipos derivados de User
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Admin>("Admin")
                .HasValue<Client>("Client")
                .HasValue<Dev>("Dev");

            // Configuracion de la clave primaria para CommercialInvoice
            modelBuilder.Entity<CommercialInvoice>()
                .HasKey(ci => ci.IdOrden);

            // Configuracion de User y las entidades que heredan de User
            modelBuilder.Entity<Admin>().HasBaseType<User>();
            modelBuilder.Entity<Client>().HasBaseType<User>();
            modelBuilder.Entity<Dev>().HasBaseType<User>();

            // Relación uno a uno entre Cliente y ShoppingCart
            modelBuilder.Entity<Client>()
                .HasOne(c => c.ShoppingCart)
                .WithOne()
                .HasForeignKey<ShoppingCart>(sc => sc.ClientId);

            // Rel uno a muchos entre Cliente y CommercialInvoice
            modelBuilder.Entity<Client>()
                .HasMany(c => c.CommercialInvoices)
                .WithOne()
                .HasForeignKey(ci => ci.ClientId);

            // Rel muchos a muchos entre ShoppingCart y Producto
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.Productos)
                .WithMany(p => p.ShoppingCarts)
                .UsingEntity<Dictionary<string, object>>(
                    "ShoppingCartProducto",
                    j => j.HasOne<Producto>().WithMany().HasForeignKey("ProductoId"),
                    j => j.HasOne<ShoppingCart>().WithMany().HasForeignKey("ShoppingCartId"));
            // Configurar el campo Role en la tabla Users
            modelBuilder.Entity<User>()
                .Property(u => u.Role)             // Selecciona la propiedad Role de la entidad User
                .IsRequired()                      // Indica que este campo es obligatorio (NOT NULL)
                .HasMaxLength(10);                 // Define la longitud máxima del campo

        }
    }
}