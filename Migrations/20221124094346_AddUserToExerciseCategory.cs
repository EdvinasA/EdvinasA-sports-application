using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class AddUserToExerciseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExerciseCategories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_UserId",
                table: "ExerciseCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseCategories_User_UserId",
                table: "ExerciseCategories",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseCategories_User_UserId",
                table: "ExerciseCategories");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseCategories_UserId",
                table: "ExerciseCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExerciseCategories");
        }
    }
}
