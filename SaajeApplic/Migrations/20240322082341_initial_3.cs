using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaajeApplic.Migrations
{
    /// <inheritdoc />
    public partial class initial_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUserId",
                table: "Commentaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_AspNetUsers_AppUserId",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Commentaires");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Projets",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Projets_AppUserId",
                table: "Projets",
                newName: "IX_Projets_AppUsersId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Commentaires",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaires_AppUserId",
                table: "Commentaires",
                newName: "IX_Commentaires_AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUsersId",
                table: "Commentaires",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_AspNetUsers_AppUsersId",
                table: "Projets",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUsersId",
                table: "Commentaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Projets_AspNetUsers_AppUsersId",
                table: "Projets");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Projets",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projets_AppUsersId",
                table: "Projets",
                newName: "IX_Projets_AppUserId");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Commentaires",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaires_AppUsersId",
                table: "Commentaires",
                newName: "IX_Commentaires_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Commentaires",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUserId",
                table: "Commentaires",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projets_AspNetUsers_AppUserId",
                table: "Projets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
