using Microsoft.EntityFrameworkCore;
using System;
using Models;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Contratos> Contratos { get; set; } = null!;
        public DbSet<Planes> Planes { get; set; } = null!;
        public DbSet<TipoPlanes> TipoPlanes { get; set; } = null!;
        public DbSet<Pagos> Pagos { get; set; } = null!;
        public DbSet<TipoPagos> TipoPagos { get; set; } = null!;
        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= ./DATA/TelecableBeavers.db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Users
            {
                builder.Entity<Usuarios>().HasData(new Usuarios
                    {
                        UsuarioId = 1,
                        Nombres = "Luis Rafael Baltodano",
                        UserName = "RafaelB",
                        Password = "20200070"
                    });

                builder.Entity<Usuarios>().HasData(new Usuarios
                    {
                        UsuarioId = 2,
                        Nombres = "Jeison Reyes",
                        UserName = "JeisonR",
                        Password = "20190564"
                    });

                builder.Entity<Usuarios>().HasData(new Usuarios
                    {
                        UsuarioId = 3,
                        Nombres = "Samuel Duran",
                        UserName = "SamuelD",
                        Password = "20190793"
                    });

                builder.Entity<Usuarios>().HasData(new Usuarios
                    {
                        UsuarioId = 4,
                        Nombres = "Elianny Rosario",
                        UserName = "EliannyR",
                        Password = "20190255"
                    });

                builder.Entity<Usuarios>().HasData(new Usuarios
                {
                    UsuarioId = 5,
                    Nombres = "Yunilda Justo",
                    UserName = "YunildaJ",
                    Password = "20190274"
                });
                builder.Entity<Usuarios>().HasData(new Usuarios
                {
                    UsuarioId = 6,
                    Nombres = "Usuario Admin",
                    UserName = "admin",
                    Password = null
                });
            }
            // Tipo Planes
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
            }
            //Tipo Pagos
			{
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
            //Planes por defecto 
            {
                builder.Entity<Planes>().HasData(new Planes
                {
                    PlanId = 1,
                    Nombre = "Combo Básico",
                    Precio = 1000.00f,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Descripcion = "3 Mbps/1 Mbps + 150 canales",
                    TipoPlanId = 1,
                    Estado = true,
                    Existente = false
                });
                builder.Entity<Planes>().HasData(new Planes
                {
                    PlanId = 2,
                    Nombre = "Combo Medio",
                    Precio = 1700.00f,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Descripcion = "10 Mbps/3 Mbps + 175 canales",
                    TipoPlanId = 2,
                    Estado = true,
                    Existente = false
                });
                builder.Entity<Planes>().HasData(new Planes
                {
                    PlanId = 3,
                    Nombre = "Combo Premium",
                    Precio = 2850.00f,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Descripcion = "50 Mbps/10 Mbps + 275 canales",
                    TipoPlanId = 3,
                    Estado = true,
                    Existente = false
                });
                builder.Entity<Planes>().HasData(new Planes
                {
                    PlanId = 4,
                    Nombre = "Combo Deluxe",
                    Precio = 2500.00f,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    Descripcion = "25 Mbps/5 Mbps + 225 canales",
                    TipoPlanId = 3,
                    Estado = true,
                    Existente = false
                });
            }
        }
    }
}