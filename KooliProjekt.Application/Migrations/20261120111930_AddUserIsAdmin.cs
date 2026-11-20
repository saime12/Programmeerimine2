using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIsAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_ProjectTasks_ProjectTaskid",
                table: "ProjectFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_Projectid",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_ProjectTasks_ProjectTaskid",
                table: "WorkLogs");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskid",
                table: "WorkLogs",
                newName: "ProjectTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_ProjectTaskid",
                table: "WorkLogs",
                newName: "IX_WorkLogs_ProjectTaskId");

            migrationBuilder.RenameColumn(
                name: "Projectid",
                table: "ProjectTasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProjectTasks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_Projectid",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskid",
                table: "ProjectFiles",
                newName: "ProjectTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectFiles_ProjectTaskid",
                table: "ProjectFiles",
                newName: "IX_ProjectFiles_ProjectTaskId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_ProjectTasks_ProjectTaskId",
                table: "ProjectFiles",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_ProjectTasks_ProjectTaskId",
                table: "WorkLogs",
                column: "ProjectTaskId",
                principalTable: "ProjectTasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_ProjectTasks_ProjectTaskId",
                table: "ProjectFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_ProjectTasks_ProjectTaskId",
                table: "WorkLogs");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "WorkLogs",
                newName: "ProjectTaskid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_ProjectTaskId",
                table: "WorkLogs",
                newName: "IX_WorkLogs_ProjectTaskid");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectTasks",
                newName: "Projectid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProjectTasks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_Projectid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjectTaskId",
                table: "ProjectFiles",
                newName: "ProjectTaskid");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectFiles_ProjectTaskId",
                table: "ProjectFiles",
                newName: "IX_ProjectFiles_ProjectTaskid");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_ProjectTasks_ProjectTaskid",
                table: "ProjectFiles",
                column: "ProjectTaskid",
                principalTable: "ProjectTasks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_Projectid",
                table: "ProjectTasks",
                column: "Projectid",
                principalTable: "Projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_ProjectTasks_ProjectTaskid",
                table: "WorkLogs",
                column: "ProjectTaskid",
                principalTable: "ProjectTasks",
                principalColumn: "id");
        }
    }
}
