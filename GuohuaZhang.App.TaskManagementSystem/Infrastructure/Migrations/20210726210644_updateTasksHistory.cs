using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateTasksHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskId_Users_UsersId",
                table: "TaskId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskId",
                table: "TaskId");

            migrationBuilder.RenameTable(
                name: "TaskId",
                newName: "TasksHistory");

            migrationBuilder.RenameIndex(
                name: "IX_TaskId_UsersId",
                table: "TasksHistory",
                newName: "IX_TasksHistory_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TasksHistory",
                table: "TasksHistory",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TasksHistory",
                table: "TasksHistory");

            migrationBuilder.RenameTable(
                name: "TasksHistory",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TaskId",
                newName: "IX_TaskId_UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskId",
                table: "TaskId",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskId_Users_UsersId",
                table: "TaskId",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
