using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName", "ShortName" },
                values: new object[,]
                {
                    { 1, "Accounting", " ACC" },
                    { 2, "Marketing", " MKT" },
                    { 3, "Administration", " ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DepartmentId", "EmployeeAge", "EmployeeName", "Hometown", "Residence" },
                values: new object[,]
                {
                    { 1, 1, 30, "Silas Yeboah", "Techiman", "West Legon" },
                    { 2, 2, 28, "Bobby Brown", "Accra", "East Legon" },
                    { 3, 3, 26, "Drey Yeboah", "Kumasi", "Sakumono" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
