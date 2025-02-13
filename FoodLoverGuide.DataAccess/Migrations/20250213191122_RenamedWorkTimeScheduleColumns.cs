using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodLoverGuide.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamedWorkTimeScheduleColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "WorkTimeSchedules",
                newName: "OpeningTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "WorkTimeSchedules",
                newName: "ClosingTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "WorkTimeSchedules",
                newName: "Day");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpeningTime",
                table: "WorkTimeSchedules",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "WorkTimeSchedules",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ClosingTime",
                table: "WorkTimeSchedules",
                newName: "End");
        }
    }
}
