using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestArdalisSpecification.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Department", "JobTitle" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "IT", "Software Engineer" },
                    { 2, "Jane", "Smith", "HR", "HR Manager" },
                    { 3, "Michael", "Johnson", "Finance", "Accountant" },
                    { 4, "Emily", "Davis", "Marketing", "Marketing Specialist" },
                    { 5, "Chris", "Brown", "IT", "System Administrator" },
                    { 6, "Anna", "Williams", "Sales", "Sales Manager" },
                    { 7, "David", "Jones", "Customer Support", "Support Representative" },
                    { 8, "Sophia", "Garcia", "Logistics", "Logistics Coordinator" },
                    { 9, "James", "Martinez", "IT", "DevOps Engineer" },
                    { 10, "Olivia", "Rodriguez", "Operations", "Operations Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int id = 1; id <= 10; id++)
            {
                migrationBuilder.DeleteData(
                    table: "Employees",
                    keyColumn: "Id",
                    keyValue: id);
            }
        }
    }
}
