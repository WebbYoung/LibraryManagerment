using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.ModelConfigs
{
	public class UserConfig : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");
			builder.HasKey(x => x.Id);
			builder.Property(e => e.PhoneNum).HasMaxLength(16);
			builder.Property(e => e.PasswordHash).HasMaxLength(64);
			builder.Property(e => e.PasswordSalt).HasMaxLength(16);
			builder.HasQueryFilter(e => !e.IsDeleted);
		}
	}
}
