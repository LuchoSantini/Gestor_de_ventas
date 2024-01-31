using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            _productoService.AgregarProducto(productoDTO);
            return Ok(productoDTO);
        }
    }
}
