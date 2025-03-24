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
	public class ContactConfiguration : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder.Property(x => x.Mail).IsRequired();
			builder.Property(x => x.Location).IsRequired();
			builder.Property(x => x.Phone).IsRequired();
			builder.Property(x => x.CreateAt).HasDefaultValueSql("GETUTCDATE()");
			builder.Property(x => x.UpdateAt).HasDefaultValueSql("GETUTCDATE()");

			builder.HasData(new Contact
			{
				Id = 1,
				Location = "Narimanov",
				Phone = "0000000",
				Mail = "Test@gmail.com"
			});
        }
	}
}
