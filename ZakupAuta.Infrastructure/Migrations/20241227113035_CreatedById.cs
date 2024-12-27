using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZakupAuta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EncodedName",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CreatedById",
                table: "Listings",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_CreatedById",
                table: "Listings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_CreatedById",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CreatedById",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Listings");

            migrationBuilder.AlterColumn<string>(
                name: "EncodedName",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
