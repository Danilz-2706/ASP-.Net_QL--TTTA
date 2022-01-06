using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Config
{
    public class ThiSinhConfiguration : IEntityTypeConfiguration<ThiSinh>
    {
        public void Configure(EntityTypeBuilder<ThiSinh> builder)
        {
            builder.ToTable("ThiSinh");
            builder.HasKey(ts => ts.CMND);
            builder.Ignore(ts => ts.SoBaoDanh);
            //One-to-one SBD
            builder.HasOne(ts => ts.SBD).WithOne(sbd => sbd.ThiSinh).HasForeignKey<SoBaoDanh>(ts => ts.CMND);
            builder.HasData(new ThiSinh { CMND = "231852123", HoTen = "Trương Đạt Nhân", GioiTinh = Gender.MALE,NgaySinh= new DateTime(2000, 11, 03),
            Email = "truongdatnhan@gmail.com",NoiSinh = "Ninh Thuận",NoiCap = "Ninh Thuận",NgayCap = new DateTime(2016,12,22),SDT="0913771045"}
                );
            /*//Many-to-many with Khoá thi
            builder.HasMany(ts => ts.KhoaThis).WithMany(kt => kt.ThiSinhs).UsingEntity<DanhSachDangKy>(
                    e => e.HasOne<KhoaThi>().WithMany().HasForeignKey(e => e.MaKT),
                    e => e.HasOne<ThiSinh>().WithMany().HasForeignKey(e => e.SBD),
                    e =>
                    {
                        e.ToTable("DanhSachDangKy");
                    }
               );
            */
            /*builder.HasMany(ts => ts.KhoaThis).WithMany(kt => kt.ThiSinhs).UsingEntity<DanhSachDangKy>(
                    j => j.HasOne(ds => ds.KhoaThi).WithMany(kt => kt.DanhSachDangKi).HasForeignKey(ds => ds.MaKT),
                    j => j.HasOne(ds => ds.ThiSinh).WithMany(ts => ts.DanhSachDangKi).HasForeignKey(ds => ds.SBD),
                    j =>
                    {
                        j.ToTable("DanhSachDangKy");
                        j.HasKey(ds => new { ds.SBD, ds.MaKT });
                    }
               );*/
        }
    }
}
