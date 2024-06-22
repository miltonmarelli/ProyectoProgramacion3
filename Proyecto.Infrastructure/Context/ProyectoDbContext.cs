using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Models;


namespace Proyecto.Infraestructure.Context
{
    public class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}