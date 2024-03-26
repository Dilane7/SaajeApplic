using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaajeApplic.Migrations
{
    /// <inheritdoc />
    public partial class initial_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUsersId",
                table: "Commentaires");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_AspNetUsers_AppUserId",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Commentaires");

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
        }
    }
}
