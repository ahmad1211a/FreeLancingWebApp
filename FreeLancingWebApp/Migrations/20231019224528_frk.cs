using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class frk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_jobs_ServiceId",
                table: "jobs",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_services_ServiceId",
                table: "jobs",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_services_ServiceId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_ServiceId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "jobs");
        }
    }
}
