using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityWorker.Migrations
{
    public partial class TakeUserLoginIndexed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "UserList",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserList_Login",
                table: "UserList",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserList_Login",
                table: "UserList");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "UserList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
