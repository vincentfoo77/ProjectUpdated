using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Server.Migrations
{
    public partial class newdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 22, 48, 200, DateTimeKind.Local).AddTicks(7757), new DateTime(2022, 1, 19, 11, 22, 48, 200, DateTimeKind.Local).AddTicks(7446), new DateTime(2022, 1, 19, 10, 22, 48, 200, DateTimeKind.Local).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 22, 48, 200, DateTimeKind.Local).AddTicks(8251), new DateTime(2022, 1, 19, 11, 22, 48, 200, DateTimeKind.Local).AddTicks(8250), new DateTime(2022, 1, 19, 10, 22, 48, 200, DateTimeKind.Local).AddTicks(8245) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "EndingTime", "EventName", "Participants", "StartingTime", "Venue" },
                values: new object[] { 3, 1, new DateTime(2022, 1, 19, 9, 22, 48, 200, DateTimeKind.Local).AddTicks(8255), new DateTime(2022, 1, 19, 11, 22, 48, 200, DateTimeKind.Local).AddTicks(8254), "Make up class", 20, new DateTime(2022, 1, 19, 10, 22, 48, 200, DateTimeKind.Local).AddTicks(8253), "Classroom" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 20, 21, 52, DateTimeKind.Local).AddTicks(2071), new DateTime(2022, 1, 19, 11, 20, 21, 52, DateTimeKind.Local).AddTicks(451), new DateTime(2022, 1, 19, 10, 20, 21, 48, DateTimeKind.Local).AddTicks(6320) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 20, 21, 52, DateTimeKind.Local).AddTicks(5311), new DateTime(2022, 1, 19, 11, 20, 21, 52, DateTimeKind.Local).AddTicks(5304), new DateTime(2022, 1, 19, 10, 20, 21, 52, DateTimeKind.Local).AddTicks(5274) });
        }
    }
}
