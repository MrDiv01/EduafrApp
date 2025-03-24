using EEWF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Data.Configurations
{
    public class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.Property(x => x.IsCorrect).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasData(new Variant
            {
                Id = 1,
                IsCorrect = true,
                Name = "Test",
                Description = "DescriptionTest",
            });
        }
    }
}
