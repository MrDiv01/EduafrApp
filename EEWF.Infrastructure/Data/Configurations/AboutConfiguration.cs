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
	public class AboutConfiguration : IEntityTypeConfiguration<About>
	{
		public void Configure(EntityTypeBuilder<About> builder)
		{
			builder.Property(x => x.Image).IsRequired();
			builder.Property(x => x.Title).IsRequired();
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
			builder.HasData(new About
			{
				Id=1,
                Title = "Titl",
                Description = "Titil ID 1",
                Image = "~/",
            });
		}
	}
}
