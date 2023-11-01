using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class iu5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobStatus",
                table: "jobs",
                newName: "UName");

            migrationBuilder.RenameColumn(
                name: "JobRate",
                table: "jobs",
                newName: "UEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UName",
                table: "jobs",
                newName: "JobStatus");

            migrationBuilder.RenameColumn(
                name: "UEmail",
                table: "jobs",
                newName: "JobRate");
        }
    }
}
