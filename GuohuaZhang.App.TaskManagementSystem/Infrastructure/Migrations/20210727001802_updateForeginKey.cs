using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class updateForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UsersId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UsersId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "TasksHistory");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_userid",
                table: "Tasks",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_userid",
                table: "Tasks",
                column: "userid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksHistory_Users_UserId",
                table: "TasksHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_userid",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksHistory_Users_UserId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_TasksHistory_UserId",
                table: "TasksHistory");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_userid",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "TasksHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TasksHistory_UsersId",
                table: "TasksHistory",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UsersId",
                table: "Tasks",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UsersId",
                table: "Tasks",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksHistory_Users_UsersId",
                table: "TasksHistory",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
