using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProductService.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Armamos configuración manualmente porque estamos fuera de Program.cs
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Ubicación actual del proyecto
                .AddJsonFile("appsettings.json") // Leemos la configuración normal
                .Build();

            // Obtenemos la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString); // Porque usamos PostgreSQL

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
