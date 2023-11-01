using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class mkl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "services");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "services");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "services");

            migrationBuilder.DropColumn(
                name: "JobRate",
                table: "services");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "services");

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Ispublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.JobId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobRate",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobStatus",
                table: "services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
