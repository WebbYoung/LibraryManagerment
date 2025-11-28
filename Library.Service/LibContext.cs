using Library.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Service
{
	public class LibContext:DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<BookType> Types { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=.;Database=Lib;Trusted_Connection=True;TrustServerCertificate=True");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
