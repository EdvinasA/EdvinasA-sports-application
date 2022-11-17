using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class AddUserToWorkoutExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WorkoutExercise",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercise_UserId",
                table: "WorkoutExercise",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_User_UserId",
                table: "WorkoutExercise",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_User_UserId",
                table: "WorkoutExercise");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutExercise_UserId",
                table: "WorkoutExercise");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkoutExercise");
        }
    }
}
