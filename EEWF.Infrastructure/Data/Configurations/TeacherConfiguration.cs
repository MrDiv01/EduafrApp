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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            //builder.Property(x => x.TeacherCategoryId).IsRequired();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");

            builder.HasData(new Teacher
            {
                Id = 1,
                Name = "Test",
                Surname = "Test",
                Description = "Test",
                Image = "Test"
            });
        }
    }
}
