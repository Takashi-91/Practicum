using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Shared.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var cs = cfg.GetConnectionString("RealTimeDb")
                ?? "Server=(localdb)\\MSSQLLocalDb;Database=RealTimeCommerceDb;Trusted_Connection=True;";

            var opts = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(cs)
                .Options;

            return new AppDbContext(opts);
        }
    }
}

