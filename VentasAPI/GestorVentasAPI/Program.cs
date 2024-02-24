using GestorVentasAPI.Context;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GestorVentasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Conexi�n a la base de datos (SQLITE). Luego mgirar a SQLServer.
            builder.Services.AddDbContext<VentasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registra ExportarDBExcelService con la cadena de conexi�n
            builder.Services.AddSingleton<IExportarDBExcelService>(provider =>
            {
                // Obtiene la cadena de conexi�n desde la configuraci�n
                string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                // Crea una instancia de ExportarDBExcelService pasando la cadena de conexi�n
                return new ExportarDBExcelService(connectionString);
            });

            #region Inyecciones de dependencia
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IVentaService, VentaService>();
            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddScoped<IDeudaClienteService, DeudaClienteService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<IFlujoFondoService,FlujoFondosService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
