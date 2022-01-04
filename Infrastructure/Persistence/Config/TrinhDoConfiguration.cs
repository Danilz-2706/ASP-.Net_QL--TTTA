using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class TrinhDoConfiguration : IEntityTypeConfiguration<TrinhDo>
    {
        public void Configure(EntityTypeBuilder<TrinhDo> builder)
        {
            builder.ToTable("TrinhDo");
            builder.HasKey(td => td.TenTrinhDo);
            builder.HasData(
                new TrinhDo { MaTrinhDo ="A2",TenTrinhDo = "A2" },
                new TrinhDo { MaTrinhDo = "B1", TenTrinhDo = "B1" }
                );
        }
    }
}