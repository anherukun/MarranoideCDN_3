using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarranoideCDN_3.Migrations
{
    public partial class sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    IDSession = table.Column<string>(type: "varchar(767)", nullable: false),
                    IDAccount = table.Column<string>(type: "text", nullable: false),
                    SessionToken = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.IDSession);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "513E4F4B-2360-40EC-B342-33A043AB02EA",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 18, 43, 48, 659, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "62F36B2A-F1F8-4399-942F-4190771F9FCD",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 18, 43, 48, 659, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "66CA7A17-E182-498F-AC3C-7AC25AD7ACD1",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 18, 43, 48, 656, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "8A5AC66A-C705-471F-B508-66D4A036176D",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 18, 43, 48, 659, DateTimeKind.Local).AddTicks(2429));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "513E4F4B-2360-40EC-B342-33A043AB02EA",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 17, 58, 46, 482, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "62F36B2A-F1F8-4399-942F-4190771F9FCD",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 17, 58, 46, 482, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "66CA7A17-E182-498F-AC3C-7AC25AD7ACD1",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 17, 58, 46, 479, DateTimeKind.Local).AddTicks(9297));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "IDAccount",
                keyValue: "8A5AC66A-C705-471F-B508-66D4A036176D",
                column: "CreatedAt",
                value: new DateTime(2021, 10, 9, 17, 58, 46, 482, DateTimeKind.Local).AddTicks(637));
        }
    }
}
