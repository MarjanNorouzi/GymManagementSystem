using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGymFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("f567631f-51f5-4bb5-9459-4d579e45418f"));

            migrationBuilder.CreateTable(
                name: "Gym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaxRooms = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomIds = table.Column<string>(type: "TEXT", nullable: false),
                    TrainerIds = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("3307892f-aa4a-425e-b807-84becae6d5cc"), new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"), new Guid("d0bc2dcd-5a4b-479c-8dfa-0bfb7aea78dd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gym");

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("3307892f-aa4a-425e-b807-84becae6d5cc"));

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("f567631f-51f5-4bb5-9459-4d579e45418f"), new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"), new Guid("30047dbd-a9e7-414e-829c-cb2eabced877") });
        }
    }
}
