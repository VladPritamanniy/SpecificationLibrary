using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestArdalisSpecification.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Offices",
            columns: new[] { "Id", "Location" },
            values: new object[,]
            {
                { 1, "New York" },
                { 2, "San Francisco" },
                { 3, "London" },
                { 4, "Tokyo" },
                { 5, "Berlin" }
            });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "OfficeId", "FirstName", "LastName", "Department", "JobTitle" },
                values: new object[,]
                {
                    { 1, 1, "John", "Doe", "IT", "Software Engineer" },
                    { 2, 2, "Jane", "Smith", "HR", "HR Manager" },
                    { 3, 3, "Michael", "Brown", "Finance", "Accountant" },
                    { 4, 4, "Emily", "Davis", "Marketing", "Marketing Specialist" },
                    { 5, 5, "Chris", "Wilson", "IT", "System Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
