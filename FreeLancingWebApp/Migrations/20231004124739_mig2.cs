using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
