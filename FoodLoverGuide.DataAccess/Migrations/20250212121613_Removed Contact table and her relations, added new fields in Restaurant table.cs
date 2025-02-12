using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovedContacttableandherrelationsaddednewfieldsinRestauranttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSite",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "WebSite",
                table: "Restaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_RestaurantId",
                table: "Contacts",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");
        }
    }
}
