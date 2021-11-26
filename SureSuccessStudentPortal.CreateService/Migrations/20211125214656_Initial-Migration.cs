using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SureSuccessStudentPortal.CreateService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Country", "Email", "FirstName", "LastName", "PhoneNo", "State" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"), "Nigeria", "ade@gmail.com", "Abdulhamiid", "Bankole", "08148738864", "Lagos" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Country", "Email", "FirstName", "LastName", "PhoneNo", "State" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"), "Nigeria", "ade@gmail.com", "John", "Tosin", "08145789548", "Osun" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Country", "Email", "FirstName", "LastName", "PhoneNo", "State" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"), "Nigeria", "oyin@yahoo.com", "Live", "Kunle", "08145788541", "Ogun" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
