using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Contratos> Contratos { get; set; }
		public DbSet<TipoPlanes> TipoPlanes { get; set; }
		public DbSet<Pagos> Pagos {get; set;}
		public DbSet<TipoPagos> TipoPagos {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source= DATA/TelecableBeavers.db");
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				PlanId = 1,
				NombrePlan = "Plan Básico",
				PrecioPlan = 550,
				Descripcion = "Plan básico de telecable beavers"
			});
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				PlanId = 2,
				NombrePlan = "Plan Medio",
				PrecioPlan = 750,
				Descripcion = "Plan Medio de telecable beavers"
			});
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				PlanId = 3,
				NombrePlan = "Plan Premium",
				PrecioPlan = 950,
				Descripcion = "Plan premium de telecable beavers"
			});

		}
		
	}
}