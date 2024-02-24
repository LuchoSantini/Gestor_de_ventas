using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace GestorVentasAPI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost("Agregar Producto")]
        public IActionResult AgregarProducto([FromBody] ProductoDTO productoDTO)
        {
            if (_productoService.AgregarProducto(productoDTO))
            {
                return Ok("Producto agregado exitosamente");
            }
            return BadRequest("El producto ya existe");
        }

        [HttpGet("Traer Productos")]
        public IActionResult TraerProductos()
        {
            var productos = _productoService.TraerProductos();
            return Ok(productos);
        }

        [HttpPut("Editar Producto{id}")]
        public IActionResult EditarProducto(ProductoDTO productoDTO)
        {
            if (_productoService.EditarProducto(productoDTO))
            {
                return Ok($"Se editó el Producto con el siguiente ID: {productoDTO.Id}");
            }
            return BadRequest("Producto no encontrado");
        }

        [HttpPut("DarDeAltaProducto Producto{idProducto}")]
        public IActionResult DarDeAltaProducto(int idProducto)
        {
            _productoService.DarDeAltaProducto(idProducto);
            return Ok($"Se ha dado de alta al producto con el ID : {idProducto}");
        }

        [HttpDelete("Eliminar Producto{idProducto}")]
        public IActionResult DarDeBajaProducto(int idProducto)
        {
            _productoService.EliminarProducto(idProducto);
            return Ok($"Se ha dado de baja al producto con el ID : {idProducto}");
        }
    }
}
