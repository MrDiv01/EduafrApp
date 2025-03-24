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
    public class CarouselConfiguration : IEntityTypeConfiguration<Carousel>
    {
        public void Configure(EntityTypeBuilder<Carousel> builder)
        {
            builder.Property(x => x.ButtonText).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasData(new Carousel
            {
                Id = 1,
                Title = "TestTitl",
                Description = "TestDescription",
                Image = "",
                Url = "#",
                ButtonText = "Click"
            });
        }
    }
}
