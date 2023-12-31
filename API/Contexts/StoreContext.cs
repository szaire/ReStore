using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
	}
}