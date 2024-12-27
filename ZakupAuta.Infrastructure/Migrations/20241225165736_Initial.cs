using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZakupAuta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingDetails_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListingDetails_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListingDetails_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListingDetails_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Encodedname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
