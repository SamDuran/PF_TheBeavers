using System;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Tecnicos> Tecnicos { get; set; } = null!;
        public DbSet<Usuarios> Usuarios { get; set; } = null!;
        public DbSet<Averias> Averias { get; set; } = null!;
        public DbSet<TipoAverias> TipoAverias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= ./DATA/TelecableBeavers.db");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Clientes>().HasData(new Clientes
                {
                    Id = 1,
                    Nombre = "Cliente No Registrado",
                    Apellido = "",
                    Cedula = ""
                });
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
            //Tecnicos
            {
                builder.Entity<Tecnicos>().HasData(new Tecnicos
                {
                    Id = 1,
                    Nombre = "Luis Rafael Baltodano P",
                    Apellido = "Baltodano",
                    NoCarnet = "1234567891"
                });
                builder.Entity<Tecnicos>().HasData(new Tecnicos
                {
                    Id = 2,
                    Nombre = "Jeison Reyes",
                    Apellido = "Reyes",
                    NoCarnet = "1234567892"
                });
                builder.Entity<Tecnicos>().HasData(new Tecnicos
                {
                    Id = 3,
                    Nombre = "Samuel Duran",
                    Apellido = "Duran",
                    NoCarnet = "1234567893"
                });
                builder.Entity<Tecnicos>().HasData(new Tecnicos
                {
                    Id = 4,
                    Nombre = "Elianny Rosario",
                    Apellido = "Rosario",
                    NoCarnet = "1234567894"
                });
                builder.Entity<Tecnicos>().HasData(new Tecnicos
                {
                    Id = 5,
                    Nombre = "Yunilda Justo",
                    Apellido = "Justo",
                    NoCarnet = "1234567895"
                });

            }
            // Tipo Averias
            {
                builder.Entity<TipoAverias>().HasData(new TipoAverias
                {
                    TipoAveriaId = 1,
                    NombreAveria = "Fibra Rota"
                });
                builder.Entity<TipoAverias>().HasData(new TipoAverias
                {
                    TipoAveriaId = 2,
                    NombreAveria = "No Señal"
                });
                builder.Entity<TipoAverias>().HasData(new TipoAverias
                {
                    TipoAveriaId = 3,
                    NombreAveria = "Averia General"
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