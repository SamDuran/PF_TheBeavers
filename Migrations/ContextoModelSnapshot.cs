﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PF_THEBEAVERS.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Models.Contratos", b =>
                {
                    b.Property<int?>("ContratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NoContrato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Plan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlanId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoReferencial")
                        .HasColumnType("TEXT");

                    b.HasKey("ContratoId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("Models.Pagos", b =>
                {
                    b.Property<int?>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("TEXT");

                    b.Property<double>("MontoPago")
                        .HasColumnType("REAL");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoPagoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PagoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Models.Planes", b =>
                {
                    b.Property<int?>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoPlanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlanId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Models.TipoPagos", b =>
                {
                    b.Property<int>("TipoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombrePago")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoPagoId");

                    b.ToTable("TipoPagos");

                    b.HasData(
                        new
                        {
                            TipoPagoId = 1,
                            NombrePago = "Efectivo"
                        },
                        new
                        {
                            TipoPagoId = 2,
                            NombrePago = "Tarjeta"
                        },
                        new
                        {
                            TipoPagoId = 3,
                            NombrePago = "Cheque"
                        });
                });

            modelBuilder.Entity("Models.TipoPlanes", b =>
                {
                    b.Property<int>("TipoPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombrePlan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoPlanId");

                    b.ToTable("TipoPlanes");

                    b.HasData(
                        new
                        {
                            TipoPlanId = 1,
                            NombrePlan = "Plan Básico"
                        },
                        new
                        {
                            TipoPlanId = 2,
                            NombrePlan = "Plan Medio"
                        },
                        new
                        {
                            TipoPlanId = 3,
                            NombrePlan = "Plan Premium"
                        });
                });

            modelBuilder.Entity("Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Nombres = "Luis Rafael Baltodano",
                            Password = "20200070",
                            UserName = "RafaelB"
                        },
                        new
                        {
                            UsuarioId = 2,
                            Nombres = "Jeison Reyes",
                            Password = "20190564",
                            UserName = "JeisonR"
                        },
                        new
                        {
                            UsuarioId = 3,
                            Nombres = "Samuel Duran",
                            Password = "20190793",
                            UserName = "SamuelD"
                        },
                        new
                        {
                            UsuarioId = 4,
                            Nombres = "Elianny Rosario",
                            Password = "20190255",
                            UserName = "EliannyR"
                        },
                        new
                        {
                            UsuarioId = 5,
                            Nombres = "Yunilda Justo",
                            Password = "20190274",
                            UserName = "YunildaJ"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
