using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parque.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Publication_idTypeOfPublication_typo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_TypePublications_IdTypeOfPulblication",
                table: "Publication");

            migrationBuilder.RenameColumn(
                name: "IdTypeOfPulblication",
                table: "Publication",
                newName: "idTypeOfPublication");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_IdTypeOfPulblication",
                table: "Publication",
                newName: "IX_Publication_idTypeOfPublication");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_TypePublications_idTypeOfPublication",
                table: "Publication",
                column: "idTypeOfPublication",
                principalTable: "TypePublications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_TypePublications_idTypeOfPublication",
                table: "Publication");

            migrationBuilder.RenameColumn(
                name: "idTypeOfPublication",
                table: "Publication",
                newName: "IdTypeOfPulblication");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_idTypeOfPublication",
                table: "Publication",
                newName: "IX_Publication_IdTypeOfPulblication");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_TypePublications_IdTypeOfPulblication",
                table: "Publication",
                column: "IdTypeOfPulblication",
                principalTable: "TypePublications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
