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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.URL).IsRequired();
            builder.Property(x => x.Icon).IsRequired();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasData(new SocialMedia
            {
                Id = 1,
                Name = "Test",
                Icon = "",
                URL = "#"
            });
        }
    }
}
