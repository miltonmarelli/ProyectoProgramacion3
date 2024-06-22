
using Proyecto.Domain.Models;
using Proyecto.Application.IServices;
using Proyecto.Application.Repositories;

namespace Proyecto.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Producto?> GetProductList()
        {
            return _repository.GetProductList();
        }

        public Producto? GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool CreateProduct(Producto producto)
        {
            if (_repository.GetById(producto.Id) != null)
            {
                return false;
            }

            return _repository.CreateProduct(producto);
        }

        public bool UpdateProduct(Producto producto)
        {
            return _repository.UpdateProduct(producto);
        }

        public bool DeleteProduct(Guid id)
        {
            return _repository.DeleteProduct(id);
        }

        public bool ApplyDiscount(Guid id, double percentage)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return false;
            }
            product.PrecioUnitario *= (1 - (percentage / 100));

            return _repository.UpdateProduct(product);
        }
    }
}