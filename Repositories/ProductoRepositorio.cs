using IndigoTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace IndigoTest.Repositories
{
    // Implementación en memoria del repositorio de productos
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly List<ProductoModel> _productos = new(); // Lista en memoria de productos
        private int _nextId = 1;

        public IEnumerable<ProductoModel> GetAll() => _productos; // Obtener todos los productos

        public ProductoModel GetById(int id) => _productos.FirstOrDefault(p => p.Id == id); // Buscar producto por el id

        // Crea un  nuevo producto
        public ProductoModel Create(ProductoModel p)
        {
            p.Id = _nextId++; // Asignar un id que no se repita y se autoincremente
            _productos.Add(p); // Agregar el producto a la lista
            return p;
        }

        // Actualizar un producto ya existente
        public bool Update(ProductoModel p)
        {
            var existente = GetById(p.Id);
            if (existente == null) return false;
            existente.Nombre = p.Nombre;
            existente.Descripcion = p.Descripcion;
            existente.CantidadEnStock = p.CantidadEnStock;
            return true;
        }
    }
}
