using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaajeApplic.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCloture",
                table: "Projets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "ProjetCreateVM",
                columns: table => new
                {
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PlanAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EtatProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCloture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetCreateVM", x => x.ProjetId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetCreateVM");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCloture",
                table: "Projets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
