using GestorVentasAPI.Context;
using GestorVentasAPI.Services.Implementations;
using GestorVentasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

            // Conexión a la base de datos (SQLITE). Luego mgirar a SQLServer.
            builder.Services.AddDbContext<VentasContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["DB:ConnectionString"]));

            #region Inyecciones de dependencia
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IVentaService, VentaService>();
            builder.Services.AddScoped<IProductoService, ProductoService>();
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
