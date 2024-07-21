
using Proyecto.Domain.Repositories;
using Proyecto.Domain.Models;
using Proyecto.Infraestructure.Context;

namespace Proyecto.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProyectoDbContext _context;

        public ProductoRepository(ProyectoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto?> GetProductList()
        {
            return _context.Productos.Where(p => p.Activo).ToList();
        }

        public Producto? GetById(Guid id)
        {
            return _context.Productos.FirstOrDefault(x => x.Id == id && x.Activo);
        }

        public bool CreateProduct(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateProduct(Producto producto)
        {
            var prod = _context.Productos.FirstOrDefault(x => x.Id == producto.Id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Descripcion = producto.Descripcion;
            prod.Stock = producto.Stock;
            prod.PrecioUnitario = producto.PrecioUnitario;
            prod.Marca = producto.Marca;
            prod.Descuento = producto.Descuento;
            prod.Image = producto.Image;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var prod = _context.Productos.FirstOrDefault(x => x.Id == id && x.Activo);

            if (prod == null)
            {
                return false;
            }

            prod.Activo = false;
            _context.SaveChanges();
            return true;
        }

        public bool ApplyDiscount(Guid id, double percentage)
        {
            var product = _context.Productos.FirstOrDefault(x => x.Id == id && x.Activo);

            if (product == null)
            {
                return false; 
            }
        
            product.PrecioUnitario *= (1 - (percentage / 100));

            _context.SaveChanges();
            return true;
        }
    }
}
