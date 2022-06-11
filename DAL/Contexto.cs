using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Contratos> Contratos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=DATA/TelecableBeavers.db");
		}
	}
}