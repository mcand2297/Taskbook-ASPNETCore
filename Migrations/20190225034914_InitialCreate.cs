using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskbook_ASPNETCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    teamId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.teamId);
                });

            migrationBuilder.CreateTable(
                name: "activities",
                columns: table => new
                {
                    activityId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    teamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activities", x => x.activityId);
                    table.ForeignKey(
                        name: "FK_activities_teams_activityId",
                        column: x => x.activityId,
                        principalTable: "teams",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    responseId = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: false),
                    activityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.responseId);
                    table.ForeignKey(
                        name: "FK_responses_activities_responseId",
                        column: x => x.responseId,
                        principalTable: "activities",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    taskId = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    isCompleted = table.Column<bool>(nullable: false),
                    activityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.taskId);
                    table.ForeignKey(
                        name: "FK_tasks_activities_taskId",
                        column: x => x.taskId,
                        principalTable: "activities",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false),
                    displayName = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    lastLogin = table.Column<DateTime>(nullable: false),
                    responseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_users_responses_userId",
                        column: x => x.userId,
                        principalTable: "responses",
                        principalColumn: "responseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taskUsers",
                columns: table => new
                {
                    taskId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskUsers", x => new { x.taskId, x.userId });
                    table.ForeignKey(
                        name: "FK_taskUsers_tasks_taskId",
                        column: x => x.taskId,
                        principalTable: "tasks",
                        principalColumn: "taskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taskUsers_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamUsers",
                columns: table => new
                {
                    teamId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    isCreator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamUsers", x => new { x.teamId, x.userId });
                    table.ForeignKey(
                        name: "FK_teamUsers_teams_teamId",
                        column: x => x.teamId,
                        principalTable: "teams",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamUsers_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taskUsers_userId",
                table: "taskUsers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_teamUsers_userId",
                table: "teamUsers",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taskUsers");

            migrationBuilder.DropTable(
                name: "teamUsers");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "activities");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
