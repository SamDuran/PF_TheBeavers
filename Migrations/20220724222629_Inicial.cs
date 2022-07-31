using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF_THEBEAVERS.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Averias",
                columns: table => new
                {
                    AveriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    TipoAveriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Averias", x => x.AveriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoContrato = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Celular = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonoReferencial = table.Column<string>(type: "TEXT", nullable: true),
                    PlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    UltimoPagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Existente = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoContrato = table.Column<string>(type: "TEXT", nullable: false),
                    TipoPagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "TEXT", nullable: false),
                    CedulaCliente = table.Column<string>(type: "TEXT", nullable: false),
                    TipoPago = table.Column<string>(type: "TEXT", nullable: false),
                    MontoPago = table.Column<float>(type: "REAL", nullable: true),
                    Asunto = table.Column<string>(type: "TEXT", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Existente = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    TipoPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoPlan = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    NoCarnet = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAverias",
                columns: table => new
                {
                    TipoAveriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAveria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAverias", x => x.TipoAveriaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagos",
                columns: table => new
                {
                    TipoPagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombrePago = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagos", x => x.TipoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanes",
                columns: table => new
                {
                    TipoPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombrePlan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanes", x => x.TipoPlanId);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    TipoUsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "Cedula", "Nombre" },
                values: new object[] { 1, "", "", "Cliente No Registrado" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "TipoPlan", "TipoPlanId" },
                values: new object[] { 1, "3 Mbps/1 Mbps + 150 canales", true, new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8017), new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8019), "Combo Básico", 1000f, "", 1 });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "TipoPlan", "TipoPlanId" },
                values: new object[] { 2, "10 Mbps/3 Mbps + 175 canales", true, new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8088), new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8090), "Combo Medio", 1700f, "", 2 });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "TipoPlan", "TipoPlanId" },
                values: new object[] { 3, "50 Mbps/10 Mbps + 275 canales", true, new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8147), new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8149), "Combo Premium", 2850f, "", 3 });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaCreacion", "FechaModificacion", "Nombre", "Precio", "TipoPlan", "TipoPlanId" },
                values: new object[] { 4, "25 Mbps/5 Mbps + 225 canales", true, new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8204), new DateTime(2022, 7, 24, 18, 26, 28, 311, DateTimeKind.Local).AddTicks(8206), "Combo Deluxe", 2500f, "", 3 });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Apellido", "NoCarnet", "Nombre" },
                values: new object[] { 1, "Baltodano", "1234567891", "Luis Rafael Baltodano" });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Apellido", "NoCarnet", "Nombre" },
                values: new object[] { 2, "Reyes", "1234567892", "Jeison Reyes" });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Apellido", "NoCarnet", "Nombre" },
                values: new object[] { 3, "Duran", "1234567893", "Samuel Duran" });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Apellido", "NoCarnet", "Nombre" },
                values: new object[] { 4, "Rosario", "1234567894", "Elianny Rosario" });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Apellido", "NoCarnet", "Nombre" },
                values: new object[] { 5, "Justo", "1234567895", "Yunilda Justo" });

            migrationBuilder.InsertData(
                table: "TipoAverias",
                columns: new[] { "TipoAveriaId", "NombreAveria" },
                values: new object[] { 1, "Fibra Rota" });

            migrationBuilder.InsertData(
                table: "TipoAverias",
                columns: new[] { "TipoAveriaId", "NombreAveria" },
                values: new object[] { 2, "No Señal" });

            migrationBuilder.InsertData(
                table: "TipoAverias",
                columns: new[] { "TipoAveriaId", "NombreAveria" },
                values: new object[] { 3, "Averia General" });

            migrationBuilder.InsertData(
                table: "TipoPagos",
                columns: new[] { "TipoPagoId", "NombrePago" },
                values: new object[] { 1, "Efectivo" });

            migrationBuilder.InsertData(
                table: "TipoPagos",
                columns: new[] { "TipoPagoId", "NombrePago" },
                values: new object[] { 2, "Tarjeta" });

            migrationBuilder.InsertData(
                table: "TipoPagos",
                columns: new[] { "TipoPagoId", "NombrePago" },
                values: new object[] { 3, "Cheque" });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "TipoPlanId", "NombrePlan" },
                values: new object[] { 1, "Plan Básico" });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "TipoPlanId", "NombrePlan" },
                values: new object[] { 2, "Plan Medio" });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "TipoPlanId", "NombrePlan" },
                values: new object[] { 3, "Plan Premium" });

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Empleado común" });

            migrationBuilder.InsertData(
                table: "TipoUsuarios",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 3, "Empleado Call Center" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 1, "Luis Rafael Baltodano", "20200070", 0, "RafaelB" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 2, "Jeison Reyes", "20190564", 0, "JeisonR" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 3, "Samuel Duran", "20190793", 0, "SamuelD" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 4, "Elianny Rosario", "20190255", 0, "EliannyR" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 5, "Yunilda Justo", "20190274", 0, "YunildaJ" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nombres", "Password", "TipoUsuarioId", "UserName" },
                values: new object[] { 6, "Usuario Admin", null, 0, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Averias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "TipoAverias");

            migrationBuilder.DropTable(
                name: "TipoPagos");

            migrationBuilder.DropTable(
                name: "TipoPlanes");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
