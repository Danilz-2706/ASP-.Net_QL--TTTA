using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Config
{
    public class KhoaThiConfiguration : IEntityTypeConfiguration<KhoaThi>
    {
        public void Configure(EntityTypeBuilder<KhoaThi> builder)
        {
            builder.ToTable("KhoaThi");
            builder.HasKey(kt => kt.MaKhoaThi);
            builder.HasData(new KhoaThi { MaKhoaThi = "KT2251", TenKhoaThi = "KT2251", NgayThi = new DateTime(2022, 01, 05) });
        }
    }
}