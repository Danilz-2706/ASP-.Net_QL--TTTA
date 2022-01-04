using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class PhongThiConfiguration : IEntityTypeConfiguration<PhongThi>
    {
        public void Configure(EntityTypeBuilder<PhongThi> builder)
        {
            builder.ToTable("PhongThi");
            builder.HasKey(p => p.MaPhongThi);
            //One-to-many trình độ
            builder.HasOne(p => p.TrinhDo).WithMany(td => td.PhongThis).HasForeignKey(p => p.MaTrinhDo);
            //One-to-many khoá thi
            builder.HasOne(p => p.KhoaThi).WithMany(kt => kt.PhongThis).HasForeignKey(p => p.MaKhoaThi);
            //Many-to-many with phòng thi
            builder.HasMany(ts => ts.GiaoViens).WithMany(gv => gv.PhongThis).UsingEntity<CanhThi>(
                    e => e.HasOne(ct => ct.GiaoVien).WithMany(gv => gv.CanhThis).HasForeignKey(ct => ct.MaGV),
                    e => e.HasOne(ct => ct.PhongThi).WithMany(p => p.CanhThis).HasForeignKey(ct => ct.MaPhongThi),
                    e =>
                    {
                        e.ToTable("CanhThi");
                        e.HasKey(t => new { t.MaGV, t.MaPhongThi });
                    }
               );
            /*builder.HasMany(ts => ts.GiaoViens).WithMany(gv => gv.PhongThis).UsingEntity<CanhThi>(
                    e => e.HasOne<GiaoVien>().WithMany().HasForeignKey(e => e.MaGV),
                    e => e.HasOne<PhongThi>().WithMany().HasForeignKey(e => e.MaPhongThi),
                    e =>
                    {
                        e.ToTable("CanhThi");
                        e.HasKey(t => new { t.MaGV,t.MaPhongThi });
                    }
               );
            */
        }
    }
}