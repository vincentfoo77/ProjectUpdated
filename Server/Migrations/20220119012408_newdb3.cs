using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Server.Migrations
{
    public partial class newdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 24, 7, 944, DateTimeKind.Local).AddTicks(8925), new DateTime(2022, 1, 19, 11, 24, 7, 944, DateTimeKind.Local).AddTicks(8478), new DateTime(2022, 1, 19, 10, 24, 7, 943, DateTimeKind.Local).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 24, 7, 944, DateTimeKind.Local).AddTicks(9685), new DateTime(2022, 1, 19, 11, 24, 7, 944, DateTimeKind.Local).AddTicks(9683), new DateTime(2022, 1, 19, 10, 24, 7, 944, DateTimeKind.Local).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 24, 7, 944, DateTimeKind.Local).AddTicks(9690), new DateTime(2022, 1, 19, 11, 24, 7, 944, DateTimeKind.Local).AddTicks(9688), new DateTime(2022, 1, 19, 10, 24, 7, 944, DateTimeKind.Local).AddTicks(9687) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Events");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "EndingTime", "StartingTime" },
                values: new object[] { new DateTime(2022, 1, 19, 9, 22, 48, 200, DateTimeKind.Local).AddTicks(8255), new DateTime(2022, 1, 19, 11, 22, 48, 200, DateTimeKind.Local).AddTicks(8254), new DateTime(2022, 1, 19, 10, 22, 48, 200, DateTimeKind.Local).AddTicks(8253) });
        }
    }
}
