using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data
{
	public class PgDBContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseNpgsql("Host=localhost;Database=firsttemp;Username=pgsqluser;Password=Password02@117");
		}

		public DbSet<Customer> Customer { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<Products> Products { get; set; }
		public DbSet<ProductOrder> ProductOrder { get; set; }

	}

}