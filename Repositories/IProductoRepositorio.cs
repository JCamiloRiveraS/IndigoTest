using IndigoTest.Models;
using System.Collections.Generic;

namespace IndigoTest.Repositories
{
    // Interfaz repositorio para gestionar productos
    public interface IProductoRepositorio
    {
        IEnumerable<ProductoModel> GetAll(); // Obtener todos los productos
        ProductoModel GetById(int id); // Obtener producto por id
        ProductoModel Create(ProductoModel p); // Crear nuevo producto p
        bool Update(ProductoModel p);// Actualizar producto p
    }
}
