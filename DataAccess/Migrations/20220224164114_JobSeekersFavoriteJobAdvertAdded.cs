using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class JobSeekersFavoriteJobAdvertAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobSeekersFavoriteJobAdvert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobAdvertId = table.Column<int>(type: "int", nullable: true),
                    JobSeekerId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekersFavoriteJobAdvert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekersFavoriteJobAdvert_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "JobAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSeekersFavoriteJobAdvert_JobSeekers_JobSeekerId",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeekers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekersFavoriteJobAdvert_JobAdvertId",
                table: "JobSeekersFavoriteJobAdvert",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekersFavoriteJobAdvert_JobSeekerId",
                table: "JobSeekersFavoriteJobAdvert",
                column: "JobSeekerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSeekersFavoriteJobAdvert");
        }
    }
}
