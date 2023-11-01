using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class bfh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "profileViewModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "profileViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "profileViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "profileViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegisterViewModelID",
                table: "profileViewModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_profileViewModels_RegisterViewModelID",
                table: "profileViewModels",
                column: "RegisterViewModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_profileViewModels_RegisterViewModel_RegisterViewModelID",
                table: "profileViewModels",
                column: "RegisterViewModelID",
                principalTable: "RegisterViewModel",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profileViewModels_RegisterViewModel_RegisterViewModelID",
                table: "profileViewModels");

            migrationBuilder.DropIndex(
                name: "IX_profileViewModels_RegisterViewModelID",
                table: "profileViewModels");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "profileViewModels");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "profileViewModels");

            migrationBuilder.DropColumn(
                name: "RegisterViewModelID",
                table: "profileViewModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "profileViewModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "profileViewModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
