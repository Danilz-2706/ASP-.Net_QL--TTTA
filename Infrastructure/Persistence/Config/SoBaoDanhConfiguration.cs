using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class SoBaoDanhConfiguration : IEntityTypeConfiguration<SoBaoDanh>
    {
        public void Configure(EntityTypeBuilder<SoBaoDanh> builder)
        {
            builder.ToTable("SoBaoDanh");
            builder.HasKey(ts => ts.SBD);
            //One-to-many trình độ
            builder.HasOne(sbd => sbd.TrinhDo).WithMany(td => td.SBDs).HasForeignKey(sbd => sbd.MaTrinhDo);
            //One-to-many khoá thi
            builder.HasOne(sbd => sbd.KhoaThi).WithMany(kt => kt.SBDs).HasForeignKey(sbd => sbd.MaKhoaThi);
            //Many-to-many with phòng thi
            builder.HasMany(ts => ts.PhongThis).WithMany(kt => kt.SoBaoDanhs).UsingEntity<ThamGiaDuThi>(
                    e => e.HasOne(tg => tg.PhongThi).WithMany(p => p.ThamGiaDuThis).HasForeignKey(tg => tg.MaPhongThi),
                    e => e.HasOne(tg => tg.SoBaoDanh).WithMany(sbd => sbd.ThamGiaDuThis).HasForeignKey(tg => tg.SBD),
                    e =>
                    {
                        e.ToTable("ThamGiaDuThi");
                        e.HasKey(t => new { t.SBD, t.MaPhongThi });
                    }
               );
            /*builder.HasMany(ts => ts.PhongThis).WithMany(kt => kt.SoBaoDanhs).UsingEntity<ThamGiaDuThi>(
                    e => e.HasOne<PhongThi>().WithMany().HasForeignKey(e => e.MaPhongThi),
                    e => e.HasOne<SoBaoDanh>().WithMany().HasForeignKey(e => e.SBD),
                    e =>
                    {
                        e.ToTable("DanhSachDangKy");
                        e.HasKey(t => new {t.SBD,t.MaPhongThi });
                    }
               );
            */
        }
    }
}