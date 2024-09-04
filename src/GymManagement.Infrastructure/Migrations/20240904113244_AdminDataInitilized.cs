using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdminDataInitilized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("3307892f-aa4a-425e-b807-84becae6d5cc"));

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "SubscriptionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("47a63386-a292-4199-9058-deb4c0657c42"), new Guid("ef5e7641-aef3-44f1-a115-39cc0da63f70"), new Guid("77a5b1f6-46ad-478e-907a-5382b78121e7") },
                    { new Guid("d27db9b6-1353-48f3-8e32-759e9a73f45c"), new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"), new Guid("e9df994f-275e-4755-bd19-6b3cbe826373") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("47a63386-a292-4199-9058-deb4c0657c42"));

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("d27db9b6-1353-48f3-8e32-759e9a73f45c"));

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("3307892f-aa4a-425e-b807-84becae6d5cc"), new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"), new Guid("d0bc2dcd-5a4b-479c-8dfa-0bfb7aea78dd") });
        }
    }
}
