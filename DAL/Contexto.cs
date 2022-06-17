using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Contratos> Contratos { get; set; }
		public DbSet<Planes> Planes {get; set;}
		public DbSet<TipoPlanes> TipoPlanes { get; set; }
		public DbSet<Pagos> Pagos {get; set;}
		public DbSet<TipoPagos> TipoPagos {get; set;}
		public DbSet<Clientes> Clientes {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source= DATA/TelecableBeavers.db");
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				TipoPlanId = 1,
				NombrePlan = "Plan Básico"
			});
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				TipoPlanId = 2,
				NombrePlan = "Plan Medio"
			});
			builder.Entity<TipoPlanes>().HasData(new TipoPlanes
			{
				TipoPlanId = 3,
				NombrePlan = "Plan Premium"
			});
			builder.Entity<TipoPagos>().HasData(new TipoPagos
			{
				TipoPagoId = 1,
				NombrePago = "Efectivo"
			});
			builder.Entity<TipoPagos>().HasData(new TipoPagos
			{
				TipoPagoId = 2,
				NombrePago = "Tarjeta"
			});
			builder.Entity<TipoPagos>().HasData(new TipoPagos
			{
				TipoPagoId = 3,
				NombrePago = "Cheque"
			});
		}
		
	}
}