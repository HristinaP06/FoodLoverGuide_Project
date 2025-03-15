using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForThirdRestaurantIntoWTSTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkTimeSchedules",
                columns: new[] { "Id", "ClosingTime", "Day", "IsClosed", "OpeningTime", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("174bc1fe-a957-41d7-8a38-afb7c1c9a340"), new TimeSpan(0, 22, 30, 0, 0), 2, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("357fa35e-6b3c-4c1d-bdfe-2951e0fc3547"), new TimeSpan(0, 22, 30, 0, 0), 6, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("7cf04ef9-fd79-40f2-935a-12b0675a6307"), new TimeSpan(0, 22, 30, 0, 0), 4, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("887e6c1a-0629-4ac2-b2fa-0370fbfbf763"), new TimeSpan(0, 22, 30, 0, 0), 1, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("898454a9-3569-4827-ae31-a6919a56351d"), new TimeSpan(0, 22, 30, 0, 0), 5, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("be5b1bad-fd82-4850-9646-1d8de29532fa"), new TimeSpan(0, 22, 30, 0, 0), 3, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") },
                    { new Guid("fbf95d72-3540-414a-94be-0d126b97cceb"), new TimeSpan(0, 22, 30, 0, 0), 0, false, new TimeSpan(0, 6, 0, 0, 0), new Guid("8670fecf-265e-4743-be6a-6477389cc15e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("174bc1fe-a957-41d7-8a38-afb7c1c9a340"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("357fa35e-6b3c-4c1d-bdfe-2951e0fc3547"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("7cf04ef9-fd79-40f2-935a-12b0675a6307"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("887e6c1a-0629-4ac2-b2fa-0370fbfbf763"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("898454a9-3569-4827-ae31-a6919a56351d"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("be5b1bad-fd82-4850-9646-1d8de29532fa"));

            migrationBuilder.DeleteData(
                table: "WorkTimeSchedules",
                keyColumn: "Id",
                keyValue: new Guid("fbf95d72-3540-414a-94be-0d126b97cceb"));
        }
    }
}
