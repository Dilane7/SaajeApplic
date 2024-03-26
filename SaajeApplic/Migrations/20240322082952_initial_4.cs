using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaajeApplic.Migrations
{
    /// <inheritdoc />
    public partial class initial_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_AspNetUsers_UserId",
                table: "Problemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Taches_AspNetUsers_AppUserId",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Taches");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Taches",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Taches_AppUserId",
                table: "Taches",
                newName: "IX_Taches_AppUsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Problemes",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Problemes_UserId",
                table: "Problemes",
                newName: "IX_Problemes_AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_AspNetUsers_AppUsersId",
                table: "Problemes",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_AspNetUsers_AppUsersId",
                table: "Taches",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_AspNetUsers_AppUsersId",
                table: "Problemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Taches_AspNetUsers_AppUsersId",
                table: "Taches");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Taches",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Taches_AppUsersId",
                table: "Taches",
                newName: "IX_Taches_AppUserId");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Problemes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Problemes_AppUsersId",
                table: "Problemes",
                newName: "IX_Problemes_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Taches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_AspNetUsers_UserId",
                table: "Problemes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_AspNetUsers_AppUserId",
                table: "Taches",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
