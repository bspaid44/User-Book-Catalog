using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLibrary.Migrations
{
    public partial class UserBooksFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks");

            migrationBuilder.DropColumn(
                name: "UserBooksId",
                table: "UserBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBooks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBooks");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserBooks");

            migrationBuilder.AddColumn<string>(
                name: "UserBooksId",
                table: "UserBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks",
                column: "UserBooksId");
        }
    }
}
