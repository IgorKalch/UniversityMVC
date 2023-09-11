using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UniversityDataLayer
{
    public class UniversityContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(System.IO.Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("DefaultString");

            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UniversityContext(optionsBuilder.Options);
        }
    }
}
