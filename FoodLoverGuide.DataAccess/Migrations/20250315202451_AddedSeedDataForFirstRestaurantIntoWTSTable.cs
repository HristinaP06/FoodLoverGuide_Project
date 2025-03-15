using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForFirstRestaurantIntoWTSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkTimeSchedules",
                columns: new[] { "Id", "ClosingTime", "Day", "IsClosed", "OpeningTime", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("16e600d3-5d1d-4f6a-afe0-2a8994f647df"), new TimeSpan(0, 23, 30, 0, 0), 5, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("4e2bbed5-ba4b-44b6-b16a-86de98a63ce0"), new TimeSpan(0, 23, 30, 0, 0), 1, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("53985eee-46ca-44e1-b457-4c3fc73e60c2"), new TimeSpan(0, 23, 30, 0, 0), 4, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("6355f560-db8e-43e5-b36b-1b282950f841"), new TimeSpan(0, 17, 30, 0, 0), 0, false, new TimeSpan(0, 12, 0, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("64bb2a3b-585c-48dd-9e0b-216ce8524a8c"), new TimeSpan(0, 23, 30, 0, 0), 3, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("dfe91a02-404b-4d36-8537-b1b82fe28d43"), new TimeSpan(0, 23, 30, 0, 0), 2, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") },
                    { new Guid("f07de646-e32b-4e34-9031-a61d1f5d3437"), new TimeSpan(0, 23, 30, 0, 0), 6, false, new TimeSpan(0, 11, 30, 0, 0), new Guid("e9d28cb7-8e75-4b36-b5f9-63a36b435c8b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("16e600d3-5d1d-4f6a-afe0-2a8994f647df"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("4e2bbed5-ba4b-44b6-b16a-86de98a63ce0"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("53985eee-46ca-44e1-b457-4c3fc73e60c2"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("6355f560-db8e-43e5-b36b-1b282950f841"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("64bb2a3b-585c-48dd-9e0b-216ce8524a8c"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("dfe91a02-404b-4d36-8537-b1b82fe28d43"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("f07de646-e32b-4e34-9031-a61d1f5d3437"));
        }
    }
}
