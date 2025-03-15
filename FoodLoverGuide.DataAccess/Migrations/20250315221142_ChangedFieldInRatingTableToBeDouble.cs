using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFieldInRatingTableToBeDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "_Rating",
                table: "Ratings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"),
                column: "_Rating",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"),
                column: "_Rating",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"),
                column: "_Rating",
                value: 5.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "_Rating",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("2e2038e6-181b-4808-8184-c38afb5a2ddc"),
                column: "_Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("84e5975b-ad32-426f-93d5-03fa0545e802"),
                column: "_Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("cdbded6f-d5d8-408b-a87c-b66f564e47af"),
                column: "_Rating",
                value: 5);
        }
    }
}
