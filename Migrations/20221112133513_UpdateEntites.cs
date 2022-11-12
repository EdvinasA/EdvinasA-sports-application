using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveApp.Migrations
{
    public partial class UpdateEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Workout_WorkoutId",
                table: "WorkoutExercise");

            migrationBuilder.RenameColumn(
                name: "WorkoutId",
                table: "WorkoutExercise",
                newName: "WorkoutEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercise_WorkoutId",
                table: "WorkoutExercise",
                newName: "IX_WorkoutExercise_WorkoutEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Workout_WorkoutEntityId",
                table: "WorkoutExercise",
                column: "WorkoutEntityId",
                principalTable: "Workout",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutExercise_Workout_WorkoutEntityId",
                table: "WorkoutExercise");

            migrationBuilder.RenameColumn(
                name: "WorkoutEntityId",
                table: "WorkoutExercise",
                newName: "WorkoutId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutExercise_WorkoutEntityId",
                table: "WorkoutExercise",
                newName: "IX_WorkoutExercise_WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutExercise_Workout_WorkoutId",
                table: "WorkoutExercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id");
        }
    }
}
