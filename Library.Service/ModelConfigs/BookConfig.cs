using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.ModelConfigs
{
	public class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books");
			builder.HasKey(x => x.Id);
			builder.HasQueryFilter(e => !e.IsDeleted);
		}
	}
}
