using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Library.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            var cfg = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Make sure base path is correct
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true) // Ensure this file is required
                .AddEnvironmentVariables()  // Include environment variables for overriding config
                .Build();

            // Get the connection string
            var connectionString = 

            // Check if connection string is null or empty
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'RealTimeDb' is not found or is empty.");
            }

            // Set up the DbContext options
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new LibraryDbContext(options);
        }
    }
}
