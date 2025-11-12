using IndigoTest.Repositories;
using IndigoTest.Models;
using IndigoTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IndigoTest.Controllers
{
    [ApiController]
    [Route("api/stock")]// Controlador gestiona stock de productos
    public class StockController : ControllerBase // Controlador para gestionar el stock de productos
    {
        private readonly IProductoRepositorio _repo;
        public StockController(IProductoRepositorio repo) => _repo = repo;

        [HttpPost("entrada/{productoId:int}")] // POST api/stock/entrada/{productoId} - Registrar entrada de stock
        public IActionResult Entrada(int productoId, [FromBody] int cantidad) // Registrar entrada de stock
        {
            if (cantidad <= 0) return BadRequest("La cantidad de entrada debe ser un número positivo mayor a 0.");

            var producto = _repo.GetById(productoId); // Obtener producto por id
            if (producto == null) return NotFound($"El producto {productoId} no existe en el Stock.");

            producto.CantidadEnStock += cantidad;
            _repo.Update(producto);
            return Ok(new { mensaje = "Entrada registrada con éxito", producto });
        }

        [HttpPost("salida/{productoId:int}")] // POST api/stock/salida/{productoId} - Registrar salida de stock
        public IActionResult Salida(int productoId, [FromBody] int cantidad) // Registrar salida de stock
        {
            if (cantidad <= 0) return BadRequest("La cantidad de salida debe ser un número positivo mayor a 0.");// Validar cantidad positiva

            var producto = _repo.GetById(productoId); 
            if (producto == null) return NotFound($"Producto {productoId} no existe o no fué encontrado."); // Validar si el producto existe

            if (producto.CantidadEnStock - cantidad < 0) // Valida si hay en stock suficientes productos
                return BadRequest("No hay productos en stock suficiente para realizar este proceso.");

            producto.CantidadEnStock -= cantidad; // Actualiza la cantidad del producto en stock
            _repo.Update(producto);// Guarda los cambios en el repositorio
            return Ok(new { mensaje = "Salida registrada con exito", producto });
        }
    }
}
