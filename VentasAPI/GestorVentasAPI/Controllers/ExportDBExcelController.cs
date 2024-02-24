using GestorVentasAPI.Data.Models;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestorVentasAPI.Controllers
{
    public class ExportDBExcelController : Controller
    {
        private readonly IExportarDBExcelService _exportarDBExcelService;

        public ExportDBExcelController(IExportarDBExcelService exportarDBExcelService)
        {
            _exportarDBExcelService = exportarDBExcelService ?? throw new ArgumentNullException(nameof(exportarDBExcelService));
        }

        [HttpPost("database")]
        public IActionResult ExportDatabaseToExcel([FromBody] ExportRequest request)
        {
            if (request == null)
            {
                return BadRequest("La solicitud no puede estar vacía.");
            }

            try
            {
                _exportarDBExcelService.ExportDatabaseToExcel(request.OutputPath);

                return Ok("Base de datos exportada exitosamente a Excel.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al exportar la base de datos a Excel: {ex.Message}");
            }
        }
    }
}
