using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechChallenge.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Document = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(250)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "varchar(15)", nullable: false),
                    RoleId = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valet_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAccess_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerVehicleId = table.Column<int>(type: "int", nullable: false),
                    ValetId = table.Column<int>(type: "int", nullable: false),
                    Entrance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeParked = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_CustomerVehicle_CustomerVehicleId",
                        column: x => x.CustomerVehicleId,
                        principalTable: "CustomerVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_ParkingSpot_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingSpot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Valet_ValetId",
                        column: x => x.ValetId,
                        principalTable: "Valet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CustomerVehicle",
                columns: new[] { "Id", "CustomerId", "PersonId", "VehicleId" },
                values: new object[] { 1, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ParkingSpot",
                columns: new[] { "Id", "Description", "Notes", "Status" },
                values: new object[] { 1, "A1", null, true });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Document", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "12345678", "admin", 1 },
                    { 2, "134567890", "cliente", 1 },
                    { 3, "199999990", "valet", 1 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "AlterDate", "CreateDate", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 24, 16, 3, 0, 648, DateTimeKind.Local).AddTicks(5135), new DateTime(2023, 10, 24, 16, 3, 0, 648, DateTimeKind.Local).AddTicks(5124), "Admin" },
                    { 2, new DateTime(2023, 10, 24, 16, 3, 0, 648, DateTimeKind.Local).AddTicks(5136), new DateTime(2023, 10, 24, 16, 3, 0, 648, DateTimeKind.Local).AddTicks(5136), "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "LicensePlate", "Model", "Notes", "VehicleType" },
                values: new object[] { 1, "Toyota", "ABC123", "Corola", null, 1 });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "PersonId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RoleAccess",
                columns: new[] { "Id", "RoleId", "Route" },
                values: new object[,]
                {
                    { 1, 1, "Auth/RefreshToken" },
                    { 2, 1, "Customer" },
                    { 3, 1, "CustomerVehicle" },
                    { 4, 1, "ParkingSpot" },
                    { 5, 1, "Reservation" },
                    { 6, 1, "Role" },
                    { 7, 1, "User" },
                    { 8, 1, "UserRole" },
                    { 9, 1, "Valet" },
                    { 10, 1, "Vehicle" },
                    { 11, 2, "Customer" },
                    { 12, 2, "Reservation" },
                    { 13, 2, "Vehicle" },
                    { 14, 2, "Auth/RefreshToken" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "PasswordHash", "PersonId", "RefreshToken", "RefreshTokenExpiryDate", "Username" },
                values: new object[] { 1, "$2a$11$h7ziM.WNMBYLxApS84Z1gOeiHBu93DfogkPzv96sDbB8.Vu87vYQ.", 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.InsertData(
                table: "Valet",
                columns: new[] { "Id", "UserId", "RoleId", "PersonId" },
                values: new object[] { 1, "98765432", new DateTime(2026, 10, 24, 16, 3, 0, 772, DateTimeKind.Local).AddTicks(5510), 3 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "CustomerVehicleId", "Entrance", "Exit", "Finished", "Paid", "ParkingSpotId", "TimeParked", "ValetId" },
                values: new object[] { 1, 1, new DateTime(2023, 10, 24, 16, 3, 0, 772, DateTimeKind.Local).AddTicks(5562), null, false, false, 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonId",
                table: "Customer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerVehicleId",
                table: "Reservation",
                column: "CustomerVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ParkingSpotId",
                table: "Reservation",
                column: "ParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ValetId",
                table: "Reservation",
                column: "ValetId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccess_RoleId",
                table: "RoleAccess",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Valet_PersonId",
                table: "Valet",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "RoleAccess");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "CustomerVehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpot");

            migrationBuilder.DropTable(
                name: "Valet");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
