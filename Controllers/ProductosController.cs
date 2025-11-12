using Microsoft.AspNetCore.Mvc;
using IndigoTest.Models;
using IndigoTest.Repositories;

namespace IndigoTest.Controllers
{
    [ApiController]
    [Route("api/productos")] // Ruta base para el controlador de productos
    public class ProductosController : ControllerBase // Controlador gestiona productos
    {
        private readonly IProductoRepositorio _repo;// Repositorio de productos
        public ProductosController(IProductoRepositorio repo) => _repo = repo;

        [HttpGet] // GET api/productos - Obtener todos los productos
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpPost] // POST api/productos - Crear nuevo producto
        public IActionResult Create([FromBody] ProductoModel producto)// Crear nuevo producto
        {
            if (producto == null) return BadRequest("El producto señaalado está vacío.");
            if (string.IsNullOrWhiteSpace(producto.Nombre)) return BadRequest("El nombre del producto a crear es un requisito obligatorio.");
            if (producto.CantidadEnStock < 0) return BadRequest("La cantidad no puede ser un número negativo.");

            var creado = _repo.Create(new ProductoModel // Crear el producto
            {
                Nombre = producto.Nombre.Trim(),
                Descripcion = producto.Descripcion?.Trim(),
                CantidadEnStock = producto.CantidadEnStock
            });

            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado); 
        }

        [HttpGet("{id:int}")]// GET api/productos/{id} - Obtener producto por el id
        public IActionResult GetById(int id) // Obtener producto por el id
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound($"Producto con id {id} no encontrado.");// Validar existencia
            return Ok(p);
        }
    }
}
