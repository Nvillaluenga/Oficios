using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oficios.Migrations
{
    public partial class FirstishMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    SkillCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.SkillCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Province = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    SkillCategoryId = table.Column<int>(nullable: true),
                    WorkerUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_SkillCategories_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategories",
                        principalColumn: "SkillCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_Users_WorkerUserId",
                        column: x => x.WorkerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opinion = table.Column<string>(maxLength: 500, nullable: true),
                    Score = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    WorkerUserId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    JobPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_WorkerUserId",
                        column: x => x.WorkerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "SkillCategories",
                columns: new[] { "SkillCategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Plomber stuff you know", "Plomber" },
                    { 2, "Electrical technician stuff you know", "Electrical technician" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "Discriminator", "Email", "LastName", "Name", "PhoneNumber", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "Houssay 1925", null, "User", "nachovillaluenga@gmail.com", "Villaluenga", "Nacho", null, 4146, null },
                    { 2, "Houssay 2925", null, "User", "nachovillaluenga2@gmail.com", "Villaluenga2", "Nacho 2", null, 4146, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "Discriminator", "Email", "LastName", "Name", "PhoneNumber", "PostalCode", "Province", "Description", "ImageUrl" },
                values: new object[,]
                {
                    { 3, "work street 1", null, "Worker", "worker@gmail.com", "Walker", "Worker", null, 4146, null, "Some description.", null },
                    { 4, "work street 2", null, "Worker", "worker2@gmail.com", "Walker2", "Worker2", null, 4146, null, "Some description2.", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Description", "Name", "SkillCategoryId", "WorkerUserId" },
                values: new object[,]
                {
                    { 3, "Various Jobs you know", "General Mantainance", 1, null },
                    { 4, "fix toilet and stuff you know", "Fix toilet", 1, null },
                    { 1, "Various Jobs you know", "General Mantainance", 2, null },
                    { 2, "change cables and stuff you know", "Change installation", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "JobPlaced", "Opinion", "Score", "SkillId", "UserId", "WorkerUserId" },
                values: new object[] { 1, new DateTime(2020, 3, 29, 22, 11, 59, 6, DateTimeKind.Local).AddTicks(3820), "A pretty good worker.", 5, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "JobPlaced", "Opinion", "Score", "SkillId", "UserId", "WorkerUserId" },
                values: new object[] { 2, new DateTime(2020, 3, 29, 22, 11, 59, 7, DateTimeKind.Local).AddTicks(5698), "A pretty good worker.", 5, 2, 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SkillId",
                table: "Jobs",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkerUserId",
                table: "Jobs",
                column: "WorkerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_WorkerUserId",
                table: "Skills",
                column: "WorkerUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
