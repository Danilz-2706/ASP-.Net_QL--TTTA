using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class CenterContext : DbContext
    {
        public CenterContext(DbContextOptions<CenterContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TourDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //apply tất cả mà không phải thêm từng cái config
        }

        public DbSet<CanhThi> CanhThis { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<KhoaThi> KhoaThis { get; set; }
        public DbSet<PhongThi> PhongThis { get; set; }
        public DbSet<SoBaoDanh> SoBaoDanhs { get; set; }
        public DbSet<ThamGiaDuThi> ThamGiaDuThis { get; set; }
        public DbSet<ThiSinh> ThiSinhs { get; set; }
        public DbSet<TrinhDo> TrinhDo { get; set; }
    }
}