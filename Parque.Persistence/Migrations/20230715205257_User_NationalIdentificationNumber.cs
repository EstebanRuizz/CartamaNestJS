using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parque.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class User_NationalIdentificationNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityDocument",
                table: "Users",
                newName: "NationalIdentificationNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalIdentificationNumber",
                table: "Users",
                newName: "IdentityDocument");
        }
    }
}
