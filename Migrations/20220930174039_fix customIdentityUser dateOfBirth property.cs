using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Extensions;

namespace UsersAPI.Migrations
{
    public partial class fixcustomIdentityUserdateOfBirthproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {      
            //migrationBuilder.Sql(@"ALTER TABLE `AspNetUsers` CHANGE COLUMN `DataNascimento` `DateOfBirth`;");

            migrationBuilder.Sql(@"ALTER TABLE AspNetUsers RENAME COLUMN DataNascimento TO DateOfBirth;");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "6ab3b59f-00c7-4aea-a597-1a0493c31ab1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9413ab51-4123-4ed9-8d70-539f7393040d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d68184b1-b219-4c05-a753-e9593207c496", "AQAAAAEAACcQAAAAECYmOdiW4b6hjdolBbaaIVvO2QB481zKanaHXZZc7hVI9xQ6Wh8sISCyupr3ezsL4Q==", "f59d7b54-b319-4c54-83fe-1be0decd517e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AspNetUsers",
                newName: "DataNascimento");

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
    }
}
