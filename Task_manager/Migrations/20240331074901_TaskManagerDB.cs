using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_manager.Migrations
{
    /// <inheritdoc />
    public partial class TaskManagerDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLeader = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DayCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Assignee = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Hide = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__B9E13D247D2FAC3A", x => x.IdProject);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Hide = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B7C92638036251C6", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    NameTask = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descreption = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DayCreate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DayReceive = table.Column<DateTime>(type: "datetime", nullable: true),
                    Hide = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Task__C454C2175F55D602", x => new { x.IdTask, x.IdProject });
                    table.ForeignKey(
                        name: "FK__Task__IdProject__440B1D61",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                });

            migrationBuilder.CreateTable(
                name: "DetailProjecet",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetailPr__EC5735EAD92DA646", x => new { x.IdUser, x.IdProject });
                    table.ForeignKey(
                        name: "FK__DetailPro__IdPro__4316F928",
                        column: x => x.IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                    table.ForeignKey(
                        name: "FK__DetailPro__IdUse__4222D4EF",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Team__21F85FE2EA619857", x => new { x.IdTeam, x.IdUser, x.IdProject });
                    table.ForeignKey(
                        name: "FK__Team__44FF419A",
                        columns: x => new { x.IdUser, x.IdProject },
                        principalTable: "DetailProjecet",
                        principalColumns: new[] { "IdUser", "IdProject" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailProjecet_IdProject",
                table: "DetailProjecet",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Task_IdProject",
                table: "Task",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdUser_IdProject",
                table: "Team",
                columns: new[] { "IdUser", "IdProject" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "DetailProjecet");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
