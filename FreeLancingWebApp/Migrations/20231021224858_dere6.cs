using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class dere6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobService");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RegisterViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditinalInformation",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "price",
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
                name: "Location",
                table: "RegisterViewModel");

            migrationBuilder.DropColumn(
                name: "AdditinalInformation",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "price",
                table: "jobs");

            migrationBuilder.CreateTable(
                name: "JobService",
                columns: table => new
                {
                    JobsJobId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobService", x => new { x.JobsJobId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_JobService_jobs_JobsJobId",
                        column: x => x.JobsJobId,
                        principalTable: "jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobService_services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobService_ServiceId",
                table: "JobService",
                column: "ServiceId");
        }
    }
}
