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
    public class GraduateConfiguration : IEntityTypeConfiguration<Graduate>
    {
        public void Configure(EntityTypeBuilder<Graduate> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Degree).IsRequired();
            builder.Property(x => x.Comment).IsRequired();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasData(new Graduate
            {
                Id = 1,
                Name = "Test",
                Degree = "Test",
                Comment = "TestComment",
                Image = ""
            });
        }
    }
}
