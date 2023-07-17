﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parque.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamepublishingstabletoEditorialandrenameid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPapers_Publishings_IdPublishing",
                table: "NewsPapers");

            migrationBuilder.DropTable(
                name: "Publishings");

            migrationBuilder.RenameColumn(
                name: "IdPublishing",
                table: "NewsPapers",
                newName: "IdEditorial");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPapers_IdPublishing",
                table: "NewsPapers",
                newName: "IX_NewsPapers_IdEditorial");

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPapers_Editorial_IdEditorial",
                table: "NewsPapers",
                column: "IdEditorial",
                principalTable: "Editorial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsPapers_Editorial_IdEditorial",
                table: "NewsPapers");

            migrationBuilder.DropTable(
                name: "Editorial");

            migrationBuilder.RenameColumn(
                name: "IdEditorial",
                table: "NewsPapers",
                newName: "IdPublishing");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPapers_IdEditorial",
                table: "NewsPapers",
                newName: "IX_NewsPapers_IdPublishing");

            migrationBuilder.CreateTable(
                name: "Publishings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPapers_Publishings_IdPublishing",
                table: "NewsPapers",
                column: "IdPublishing",
                principalTable: "Publishings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
