using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesenvolvedorNET.Migrations
{
    /// <inheritdoc />
    public partial class createTableDepartamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Empregados",
                newName: "DepartamentoId");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "TI" },
                    { 2, "RH" },
                    { 3, "Financeiro" },
                    { 4, "Comercial" },
                    { 5, "Marketing" },
                    { 6, "Administrativo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empregados_DepartamentoId",
                table: "Empregados",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_Departamentos_DepartamentoId",
                table: "Empregados",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_Departamentos_DepartamentoId",
                table: "Empregados");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Empregados_DepartamentoId",
                table: "Empregados");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Empregados",
                newName: "Departamento");
        }
    }
}
