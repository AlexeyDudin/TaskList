using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityWorker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    UserIssueId = table.Column<int>(type: "int", nullable: true),
                    UserWorkerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskList_UserList_UserIssueId",
                        column: x => x.UserIssueId,
                        principalTable: "UserList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskList_UserList_UserWorkerId",
                        column: x => x.UserWorkerId,
                        principalTable: "UserList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserIssueId",
                table: "TaskList",
                column: "UserIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskList_UserWorkerId",
                table: "TaskList",
                column: "UserWorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "UserList");
        }
    }
}
