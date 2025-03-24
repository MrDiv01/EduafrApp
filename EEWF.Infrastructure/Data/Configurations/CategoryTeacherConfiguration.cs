using EEWF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EEWF.Infrastructure.Data.Configurations
{
    public class CategoryTeacherConfiguration : IEntityTypeConfiguration<CategoryTeacher>
    {
        public void Configure(EntityTypeBuilder<CategoryTeacher> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.TeacherCategoryId).IsRequired();
            builder.Property(x=>x.TeacherId).IsRequired();

            builder.HasOne(x => x.Teacher)
                    .WithMany(x => x.CategoryTeachers)
                        .HasForeignKey(x => x.TeacherId)
                            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.TeacherCategory)
                    .WithMany(x => x.CategoryTeachers)
                        .HasForeignKey(x => x.TeacherCategoryId)
                            .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new CategoryTeacher
            {
                Id = 1,
                TeacherId = 1,
                TeacherCategoryId = 1
            });
        }
    }
}
