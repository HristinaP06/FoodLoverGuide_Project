using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedInRestaurantPhotoTableAndMenuItemForThirdRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Photo", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("0d63a2e7-200a-4f21-8e29-c1c9592c76d8"), "/img/restaurants/menuDelta7.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("16e14eea-711b-43f0-a32b-67ccbdd2f83f"), "/img/restaurants/menuDelta14.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("189a0770-4e56-4785-aa9c-8d8680db1d2a"), "/img/restaurants/menuDelta21.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("21c73c72-3656-4831-99af-f187847007dc"), "/img/restaurants/menuDelta8.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("488d1538-4276-43b1-b61c-f7832008386e"), "/img/restaurants/menuDelta15.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("5206eca9-5c20-44be-bc08-48f628d52687"), "/img/restaurants/menuDelta18.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("52224042-89be-4c71-b91e-9c370e37f6c0"), "/img/restaurants/menuDelta10.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("6fa06452-f7b6-4a74-be2d-634bdf12a292"), "/img/restaurants/menuDelta13.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("778b5ba9-57cb-4349-a773-2bc4badb4fc2"), "/img/restaurants/menuDelta22.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("841eeb59-eb0d-4d79-a1ff-c778201ad2df"), "/img/restaurants/menuDelta11.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("8a6413a9-0868-4e2b-8c71-0c2a843bca28"), "/img/restaurants/menuDelta5.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("9c4d530c-a0b7-4433-abff-b717f9b95d84"), "/img/restaurants/menuDelta9.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("9fbe7d14-b74f-4607-8330-b2172d46c1b9"), "/img/restaurants/menuDelta4.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("a8a301a9-5f9a-4a04-a9fc-5d23c9379bc3"), "/img/restaurants/menuDelta2.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("ae3fcc5d-b7ea-4058-8021-d1bf09520d40"), "/img/restaurants/menuDelta1.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("b921a7fc-4a25-45c2-8590-be88226ca9b7"), "/img/restaurants/menuDelta3.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("bc4f36c1-b70a-4d91-b82e-473d5f3cfeb6"), "/img/restaurants/menuDelta23.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("c613e9a3-d2ae-494a-97d2-995966f32b45"), "/img/restaurants/menuDelta16.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("cc9a7227-d89c-4a94-99b0-79ebd9d990e4"), "/img/restaurants/menuDelta17.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("d50bdf0c-e315-4439-9d94-85ba2cad7069"), "/img/restaurants/menuDelta6.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("e4cf6a24-e078-4f4f-9654-ac6a58b400a7"), "/img/restaurants/menuDelta20.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("e7743562-2ee1-4379-9058-0c045a08c803"), "/img/restaurants/menuDelta19.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("fbebc578-2f01-4226-aa1b-a0cb401921e4"), "/img/restaurants/menuDelta12.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                });

            migrationBuilder.InsertData(
                table: "RestaurantPhotos",
                columns: new[] { "Id", "Photo", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("0a6d4d6a-c929-4afb-9993-84595f14bda3"), "/img/restaurants/delta4.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("478d44ee-93b2-4260-a4e0-88e7bdf198ee"), "/img/restaurants/delta3.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("5e66a376-1951-4fec-ab24-088ddada70fa"), "/img/restaurants/delta2.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("e047ddf1-2c78-4b31-8ac8-7f3c101e3e83"), "/img/restaurants/delta5.png", new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0d63a2e7-200a-4f21-8e29-c1c9592c76d8"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("16e14eea-711b-43f0-a32b-67ccbdd2f83f"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("189a0770-4e56-4785-aa9c-8d8680db1d2a"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("21c73c72-3656-4831-99af-f187847007dc"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("488d1538-4276-43b1-b61c-f7832008386e"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("5206eca9-5c20-44be-bc08-48f628d52687"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("52224042-89be-4c71-b91e-9c370e37f6c0"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("6fa06452-f7b6-4a74-be2d-634bdf12a292"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("778b5ba9-57cb-4349-a773-2bc4badb4fc2"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("841eeb59-eb0d-4d79-a1ff-c778201ad2df"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("8a6413a9-0868-4e2b-8c71-0c2a843bca28"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("9c4d530c-a0b7-4433-abff-b717f9b95d84"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("9fbe7d14-b74f-4607-8330-b2172d46c1b9"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a8a301a9-5f9a-4a04-a9fc-5d23c9379bc3"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("ae3fcc5d-b7ea-4058-8021-d1bf09520d40"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b921a7fc-4a25-45c2-8590-be88226ca9b7"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("bc4f36c1-b70a-4d91-b82e-473d5f3cfeb6"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c613e9a3-d2ae-494a-97d2-995966f32b45"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("cc9a7227-d89c-4a94-99b0-79ebd9d990e4"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d50bdf0c-e315-4439-9d94-85ba2cad7069"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("e4cf6a24-e078-4f4f-9654-ac6a58b400a7"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("e7743562-2ee1-4379-9058-0c045a08c803"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fbebc578-2f01-4226-aa1b-a0cb401921e4"));

            migrationBuilder.DeleteData(
                table: "RestaurantPhotos",
                keyColumn: "Id",
                keyValue: new Guid("0a6d4d6a-c929-4afb-9993-84595f14bda3"));

            migrationBuilder.DeleteData(
                table: "RestaurantPhotos",
                keyColumn: "Id",
                keyValue: new Guid("478d44ee-93b2-4260-a4e0-88e7bdf198ee"));

            migrationBuilder.DeleteData(
                table: "RestaurantPhotos",
                keyColumn: "Id",
                keyValue: new Guid("5e66a376-1951-4fec-ab24-088ddada70fa"));

            migrationBuilder.DeleteData(
                table: "RestaurantPhotos",
                keyColumn: "Id",
                keyValue: new Guid("e047ddf1-2c78-4b31-8ac8-7f3c101e3e83"));
        }
    }
}
