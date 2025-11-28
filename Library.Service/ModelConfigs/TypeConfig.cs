using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.ModelConfigs
{
	public class TypeConfig : IEntityTypeConfiguration<BookType>
	{
		public void Configure(EntityTypeBuilder<BookType> builder)
		{
			builder.ToTable("BookTypes");
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Name).HasMaxLength(16).IsUnicode();
			builder.HasMany(e=>e.Books).WithOne(e=>e.Type).HasForeignKey(e=>e.TypeId);
			builder.HasQueryFilter(e => !e.IsDeleted);
		}
	}
}
