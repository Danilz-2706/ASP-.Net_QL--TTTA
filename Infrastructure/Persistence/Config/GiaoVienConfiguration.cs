using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class GiaoVienConfiguration : IEntityTypeConfiguration<GiaoVien>
    {
        public void Configure(EntityTypeBuilder<GiaoVien> builder)
        {
            builder.ToTable("GiaoVien");
            builder.HasKey(gv => gv.MaGV);
            builder.HasData(
                new GiaoVien {MaGV = 1, HoTen = "Ngô Ngọc Nhung", GioiTinh = Gender.FEMALE, Email="nhung22@gmail.com", SDT="0942810024" },
                new GiaoVien { MaGV = 2, HoTen = "Hồ Tấn Dũng", GioiTinh = Gender.MALE, Email = "dund@gmail.com", SDT = "0378240942" }
                );
        }
    }
}