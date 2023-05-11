using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SamsungWatch.Data.EF;

public class SamsungWatchDbContextFactory : IDesignTimeDbContextFactory<SamsungWatchDbContext>
{
    public SamsungWatchDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
        .AddJsonFile("appsettings.Development.json")
#else
        .AddJsonFile("appsettings.Production.json")
#endif
        .Build();


        var connectionString = configuration.GetConnectionString("SamsungWatchDb");

        var optionsBuilder = new DbContextOptionsBuilder<SamsungWatchDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new SamsungWatchDbContext(optionsBuilder.Options);
    }
}

