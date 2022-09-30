using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersAPI.Migrations
{
    public partial class addroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a747ffa4-a73c-44e6-a16e-9be671190577");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "855108b5-ee2e-435e-8bb1-90d409deb0c9", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c1b7f9-edbe-45b0-afc0-4f4daa5e324c", "AQAAAAEAACcQAAAAENbT6zhyAdyFtzvcey+KsuuSmUFLJoGuZrasBSRkxJ5uyQlR20fxtjfTjnT/jaa/6Q==", "3281214f-c599-49bd-bbdd-4100415ba22a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "b3ada660-1f52-4bb7-974c-fd76b4d023c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c740f743-9bf4-45e2-8acc-3fea520ce1f6", "AQAAAAEAACcQAAAAEP3M+TcnFp5IB+jvXiaYCXMiS+29Nr6yQ2J9UtU0e5wqjvAnzLw/iFgUByvU88fETg==", "e066330f-fab7-49a7-ba6c-845c1824f34e" });
        }
    }
}
