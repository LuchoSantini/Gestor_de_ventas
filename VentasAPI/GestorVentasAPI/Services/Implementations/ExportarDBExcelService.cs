using GestorVentasAPI.Services.Interfaces;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System.Data;

namespace GestorVentasAPI.Services.Implementations
{
    public class ExportarDBExcelService : IExportarDBExcelService
    {
        private readonly string _connectionString;

        public ExportarDBExcelService(string connectionString)
        {
            _connectionString = connectionString;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        public void ExportDatabaseToExcel(string outputPath)
        {
            List<string> tableNames = GetTableNames();

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                foreach (string tableName in tableNames)
                {
                    DataTable table = GetDataFromTable(tableName);
                    AddDataTableToExcel(excelPackage, table, tableName);
                }

                FileInfo excelFile = new FileInfo(outputPath);
                excelPackage.SaveAs(excelFile);
            }
        }

        public List<string> GetTableNames()
        {
            List<string> tableNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableNames.Add(reader["TABLE_NAME"].ToString());
                    }
                }
            }
            return tableNames;
        }

        public DataTable GetDataFromTable(string tableName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public void AddDataTableToExcel(ExcelPackage excelPackage, DataTable dataTable, string sheetName)
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
            worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
        }
    }
}
