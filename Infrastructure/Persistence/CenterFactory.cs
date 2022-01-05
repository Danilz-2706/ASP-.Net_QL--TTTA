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
            var optionsBuilder = new DbContextOptionsBuilder<CenterContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EnglishCenterDB;Trusted_Connection=True;");

            return new CenterContext(optionsBuilder.Options);
        }
    }
}