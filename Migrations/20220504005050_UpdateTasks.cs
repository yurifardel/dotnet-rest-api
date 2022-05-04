using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_c_.Migrations
{
    public partial class UpdateTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "tb_tasks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "tb_tasks",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tb_tasks",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "tb_tasks",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_tasks",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "tb_tasks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tasks",
                table: "tb_tasks",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tasks",
                table: "tb_tasks");

            migrationBuilder.RenameTable(
                name: "tb_tasks",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Task",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Task",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Task",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Task",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");
        }
    }
}
