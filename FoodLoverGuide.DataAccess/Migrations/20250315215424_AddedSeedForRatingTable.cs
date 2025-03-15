using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedForRatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "RestaurantId", "UserId", "_Rating" },
                values: new object[,]
                {
                    { new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b"), "bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3", 5 },
                    { new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"), new Guid("8670fecf-265e-4743-be6a-6477389cc15e"), "bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3", 5 },
                    { new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342"), "bce98f2f-6ebc-4024-ab7b-b3c1245bb6e3", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"));
        }
    }
}
