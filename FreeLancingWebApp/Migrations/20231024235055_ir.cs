using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeLancingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "RegisterViewModelID",
                table: "profileViewModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "profileViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
