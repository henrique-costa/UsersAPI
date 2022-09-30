using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
    public partial class addcustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "332cec62-479a-4155-81d6-701f11384c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "6de3e2d3-a7c3-4d88-b6e9-e0b45173782c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb1fc6b-cc27-4980-bfdb-8f82c80fa709", "AQAAAAEAACcQAAAAEFviPjlk4RjauSAjqFNvPWySWRH4kzmLkJTPJDlxKX9Xtdn5BV+2N4NHrMIVgBckhw==", "651ab140-e10a-48b2-b79c-f3c48caa7207" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "855108b5-ee2e-435e-8bb1-90d409deb0c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a747ffa4-a73c-44e6-a16e-9be671190577");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c1b7f9-edbe-45b0-afc0-4f4daa5e324c", "AQAAAAEAACcQAAAAENbT6zhyAdyFtzvcey+KsuuSmUFLJoGuZrasBSRkxJ5uyQlR20fxtjfTjnT/jaa/6Q==", "3281214f-c599-49bd-bbdd-4100415ba22a" });
        }
    }
}
