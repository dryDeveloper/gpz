using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlRepositoryAdapter.Migrations
{
    /// <inheritdoc />
    public partial class newdbctx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interior = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCreditRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    CaptureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urgent = table.Column<bool>(type: "bit", nullable: false),
                    AsignedPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfAsigment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCreditRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCreditRequests_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCreditRequests_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberId = table.Column<int>(type: "int", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCreditRequestEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressNumbers_NumberId",
                        column: x => x.NumberId,
                        principalTable: "AddressNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_ClientCreditRequests_ClientCreditRequestEntityId",
                        column: x => x.ClientCreditRequestEntityId,
                        principalTable: "ClientCreditRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PhoneTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientCreditRequestEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_ClientCreditRequests_ClientCreditRequestEntityId",
                        column: x => x.ClientCreditRequestEntityId,
                        principalTable: "ClientCreditRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneType_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalReferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    ClientCreditRequestEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalReferences_ClientCreditRequests_ClientCreditRequestEntityId",
                        column: x => x.ClientCreditRequestEntityId,
                        principalTable: "ClientCreditRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalReferences_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientCreditRequestEntityId",
                table: "Addresses",
                column: "ClientCreditRequestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NumberId",
                table: "Addresses",
                column: "NumberId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCreditRequests_ClientId",
                table: "ClientCreditRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCreditRequests_RequestTypeId",
                table: "ClientCreditRequests",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalReferences_ClientCreditRequestEntityId",
                table: "PersonalReferences",
                column: "ClientCreditRequestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalReferences_PhoneNumberId",
                table: "PersonalReferences",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ClientCreditRequestEntityId",
                table: "PhoneNumbers",
                column: "ClientCreditRequestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneTypeId",
                table: "PhoneNumbers",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PersonalReferences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AddressNumbers");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "ClientCreditRequests");

            migrationBuilder.DropTable(
                name: "PhoneType");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "RequestType");
        }
    }
}
