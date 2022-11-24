using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class AddExerciseCategoryToExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercise",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseCategoryId",
                table: "Exercise",
                column: "ExerciseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise",
                column: "ExerciseCategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_ExerciseCategories_ExerciseCategoryId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_ExerciseCategoryId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ExerciseCategoryId",
                table: "Exercise");
        }
    }
}
