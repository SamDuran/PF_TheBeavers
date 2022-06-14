using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PF_THEBEAVERS.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Comentario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanes",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombrePlan = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PrecioPlan = table.Column<decimal>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanes", x => x.PlanId);
                });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaModificacion", "NombrePlan", "PrecioPlan" },
                values: new object[] { 1, "Plan básico de telecable beavers", false, null, "Plan Básico", 550m });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaModificacion", "NombrePlan", "PrecioPlan" },
                values: new object[] { 2, "Plan Medio de telecable beavers", false, null, "Plan Medio", 750m });

            migrationBuilder.InsertData(
                table: "TipoPlanes",
                columns: new[] { "PlanId", "Descripcion", "Estado", "FechaModificacion", "NombrePlan", "PrecioPlan" },
                values: new object[] { 3, "Plan premium de telecable beavers", false, null, "Plan Premium", 950m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "TipoPlanes");
        }
    }
}
