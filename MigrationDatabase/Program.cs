using APIProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MigrationDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .Options;

            using var db = new ApplicationDbContext(options);
           
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
