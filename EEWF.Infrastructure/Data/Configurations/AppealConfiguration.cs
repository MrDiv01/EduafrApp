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
	public class AppealConfiguration : IEntityTypeConfiguration<Appeal>
	{
		public void Configure(EntityTypeBuilder<Appeal> builder)
		{
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Surname).IsRequired();
			builder.Property(x => x.Subject).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Message).IsRequired();
			builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");
			builder.HasData(new Appeal
			{
				Id = 1,
                Name = "Nurlan",
                Surname = "Mammadov",
                Email = "Test@gmail.com",
                Subject = "SunjectTest",
                Message = "MesajTest"
            });
		}
	}
}
