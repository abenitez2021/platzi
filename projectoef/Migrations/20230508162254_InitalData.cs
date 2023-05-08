using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso", "volumen" },
                values: new object[,]
                {
                    { new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea02"), null, "actividades personales", 20, 10 },
                    { new Guid("c3345a24-b7fd-4a22-859d-520f99f4eafb"), null, "actividades pendientes", 20, 10 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaID", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea03"), new Guid("c3345a24-b7fd-4a22-859d-520f99f4eafb"), null, new DateTime(2023, 5, 8, 12, 22, 54, 17, DateTimeKind.Local).AddTicks(5490), 1, "Pago de servicios" },
                    { new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea04"), new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea02"), null, new DateTime(2023, 5, 8, 12, 22, 54, 17, DateTimeKind.Local).AddTicks(5522), 0, "terminar mi serie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea03"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea04"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("c3345a24-b7fd-4a22-859d-520f99f4ea02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("c3345a24-b7fd-4a22-859d-520f99f4eafb"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
