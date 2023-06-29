using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parque.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionErrorMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Environment_IdEnviroment",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Environment",
                table: "Environment");

            migrationBuilder.RenameTable(
                name: "Environment",
                newName: "Enviroment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enviroment",
                table: "Enviroment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Enviroment_IdEnviroment",
                table: "Reservations",
                column: "IdEnviroment",
                principalTable: "Enviroment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Enviroment_IdEnviroment",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enviroment",
                table: "Enviroment");

            migrationBuilder.RenameTable(
                name: "Enviroment",
                newName: "Environment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Environment",
                table: "Environment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Environment_IdEnviroment",
                table: "Reservations",
                column: "IdEnviroment",
                principalTable: "Environment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
