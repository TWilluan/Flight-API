using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FlightNo = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeOri = table.Column<DateTime>(name: "Time_Ori", type: "datetime(6)", nullable: false),
                    TimeDes = table.Column<DateTime>(name: "Time_Des", type: "datetime(6)", nullable: false),
                    Gate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerID = table.Column<Guid>(name: "Passenger_ID", type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PassengerFlightMappings",
                columns: table => new
                {
                    PassengerID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FlightID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BookingTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerFlightMappings", x => new { x.FlightID, x.PassengerID });
                    table.ForeignKey(
                        name: "FK_PassengerFlightMappings_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerFlightMappings_Passengers_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "Passengers",
                        principalColumn: "Passenger_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightID", "Capacity", "Destination", "FlightNo", "Gate", "Origin", "Time_Des", "Time_Ori" },
                values: new object[,]
                {
                    { new Guid("b7d6a643-b638-49ce-a9a4-5c0f58aa6e08"), 150, "TSA", "AYE35", "", "DUL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 14, 16, 6, 46, 852, DateTimeKind.Local).AddTicks(8740) },
                    { new Guid("cb4b7ea6-ef3a-4340-a46a-a41e8441058f"), 180, "DUL", "EYA23", "", "TSA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Passenger_ID", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("3009d2b7-2941-46d6-920e-1e3a6e769436"), "cba@gmail.com", "Chi", "Le" },
                    { new Guid("74ac97a5-df82-4a74-8d41-35324a4c00c7"), "abc@gmail.com", "Tuan", "Vo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerFlightMappings_PassengerID",
                table: "PassengerFlightMappings",
                column: "PassengerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerFlightMappings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
