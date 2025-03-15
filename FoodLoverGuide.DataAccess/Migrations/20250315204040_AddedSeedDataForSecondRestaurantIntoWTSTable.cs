using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForSecondRestaurantIntoWTSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkTimeSchedules",
                columns: new[] { "Id", "ClosingTime", "Day", "IsClosed", "OpeningTime", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("010383fe-ebc4-48e2-b98e-2182e24bce31"), new TimeSpan(0, 23, 0, 0, 0), 4, false, new TimeSpan(0, 8, 30, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("3c519e19-9696-46a4-be31-1c42d886e1e5"), new TimeSpan(0, 0, 0, 0, 0), 1, false, new TimeSpan(0, 0, 0, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("813f0637-9a00-4612-b5a4-3b2aee6ec6ac"), new TimeSpan(0, 23, 0, 0, 0), 5, false, new TimeSpan(0, 8, 30, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("93255465-e52f-421c-b0df-ea6ef6696832"), new TimeSpan(0, 0, 0, 0, 0), 0, false, new TimeSpan(0, 0, 0, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("acf0156c-7576-42d6-9b11-984d313aea51"), new TimeSpan(0, 23, 0, 0, 0), 2, false, new TimeSpan(0, 8, 30, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("b62049ab-ee45-4415-aa0c-690dd5b50ce5"), new TimeSpan(0, 23, 0, 0, 0), 6, false, new TimeSpan(0, 8, 30, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") },
                    { new Guid("c0790a6d-08c0-4470-a533-f19f40013672"), new TimeSpan(0, 23, 0, 0, 0), 3, false, new TimeSpan(0, 8, 30, 0, 0), new Guid("b7b8ab2e-d671-4829-b35d-9814918f8342") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("010383fe-ebc4-48e2-b98e-2182e24bce31"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("3c519e19-9696-46a4-be31-1c42d886e1e5"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("813f0637-9a00-4612-b5a4-3b2aee6ec6ac"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("93255465-e52f-421c-b0df-ea6ef6696832"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("acf0156c-7576-42d6-9b11-984d313aea51"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("b62049ab-ee45-4415-aa0c-690dd5b50ce5"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("c0790a6d-08c0-4470-a533-f19f40013672"));
        }
    }
}
