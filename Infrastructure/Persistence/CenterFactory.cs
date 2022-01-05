using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Persistence
{
    public class CenterFactory : IDesignTimeDbContextFactory<CenterContext>
    {
        public CenterContext CreateDbContext(string[] args)
        {
            var connectionString = @"Server=.\SQLEXPRESS;Database=EnglishCenterDB;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<CenterContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CenterContext(optionsBuilder.Options);
        }
    }
}