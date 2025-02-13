using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangefieldsnottobenullandremovedcolumnsinRestauranttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantPhotoId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ReviewsId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "RestaurantPhotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantPhotoId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewsId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "RestaurantPhotos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
