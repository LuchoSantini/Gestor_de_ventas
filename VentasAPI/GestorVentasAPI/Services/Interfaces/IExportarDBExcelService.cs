using OfficeOpenXml;
using System.Data;

namespace GestorVentasAPI.Services.Interfaces
{
    public interface IExportarDBExcelService
    {
        public void ExportDatabaseToExcel(string outputPath);
        public List<string> GetTableNames();
        public DataTable GetDataFromTable(string tableName);
        public void AddDataTableToExcel(ExcelPackage excelPackage, DataTable dataTable, string sheetName);
    }
}
