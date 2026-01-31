using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlRepositoryAdapter.Migrations
{
    /// <inheritdoc />
    public partial class addedmissingnavigationpropertiesfor1tomanyrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressNumbers_NumberId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_Clients_ClientId",
                table: "ClientCreditRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_RequestType_RequestTypeId",
                table: "ClientCreditRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalReferences_PhoneNumbers_PhoneNumberId",
                table: "PersonalReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PhoneType_PhoneTypeId",
                table: "PhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "PhoneTypeId",
                table: "PhoneNumbers",
                newName: "PhoneTypeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_PhoneTypeId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PhoneTypeEntityId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberId",
                table: "PersonalReferences",
                newName: "PhoneNumberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalReferences_PhoneNumberId",
                table: "PersonalReferences",
                newName: "IX_PersonalReferences_PhoneNumberEntityId");

            migrationBuilder.RenameColumn(
                name: "RequestTypeId",
                table: "ClientCreditRequests",
                newName: "RequestTypeEntityId");

            migrationBuilder.RenameColumn(
                name: "ProjectType",
                table: "ClientCreditRequests",
                newName: "ProjectTypeEntityId");

            migrationBuilder.RenameColumn(
                name: "DateOfAsigment",
                table: "ClientCreditRequests",
                newName: "DateOfAssigment");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientCreditRequests",
                newName: "ClientEntityId");

            migrationBuilder.RenameColumn(
                name: "AsignedPhoneNumber",
                table: "ClientCreditRequests",
                newName: "AssignedPhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCreditRequests_RequestTypeId",
                table: "ClientCreditRequests",
                newName: "IX_ClientCreditRequests_RequestTypeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCreditRequests_ClientId",
                table: "ClientCreditRequests",
                newName: "IX_ClientCreditRequests_ClientEntityId");

            migrationBuilder.RenameColumn(
                name: "NumberId",
                table: "Addresses",
                newName: "AddressTypeEntityId");

            migrationBuilder.RenameColumn(
                name: "AddressType",
                table: "Addresses",
                newName: "AddressNumberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_NumberId",
                table: "Addresses",
                newName: "IX_Addresses_AddressTypeEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RequestType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Exterior",
                table: "AddressNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Colonia",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AddressTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCreditRequests_ProjectTypeEntityId",
                table: "ClientCreditRequests",
                column: "ProjectTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressNumberEntityId",
                table: "Addresses",
                column: "AddressNumberEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressNumbers_AddressNumberEntityId",
                table: "Addresses",
                column: "AddressNumberEntityId",
                principalTable: "AddressNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypeEntity_AddressTypeEntityId",
                table: "Addresses",
                column: "AddressTypeEntityId",
                principalTable: "AddressTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_Clients_ClientEntityId",
                table: "ClientCreditRequests",
                column: "ClientEntityId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_ProjectTypeEntity_ProjectTypeEntityId",
                table: "ClientCreditRequests",
                column: "ProjectTypeEntityId",
                principalTable: "ProjectTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_RequestType_RequestTypeEntityId",
                table: "ClientCreditRequests",
                column: "RequestTypeEntityId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalReferences_PhoneNumbers_PhoneNumberEntityId",
                table: "PersonalReferences",
                column: "PhoneNumberEntityId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PhoneType_PhoneTypeEntityId",
                table: "PhoneNumbers",
                column: "PhoneTypeEntityId",
                principalTable: "PhoneType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressNumbers_AddressNumberEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypeEntity_AddressTypeEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_Clients_ClientEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_ProjectTypeEntity_ProjectTypeEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_RequestType_RequestTypeEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalReferences_PhoneNumbers_PhoneNumberEntityId",
                table: "PersonalReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_PhoneType_PhoneTypeEntityId",
                table: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "AddressTypeEntity");

            migrationBuilder.DropTable(
                name: "ProjectTypeEntity");

            migrationBuilder.DropIndex(
                name: "IX_ClientCreditRequests_ProjectTypeEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressNumberEntityId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "PhoneTypeEntityId",
                table: "PhoneNumbers",
                newName: "PhoneTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_PhoneTypeEntityId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PhoneTypeId");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberEntityId",
                table: "PersonalReferences",
                newName: "PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalReferences_PhoneNumberEntityId",
                table: "PersonalReferences",
                newName: "IX_PersonalReferences_PhoneNumberId");

            migrationBuilder.RenameColumn(
                name: "RequestTypeEntityId",
                table: "ClientCreditRequests",
                newName: "RequestTypeId");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeEntityId",
                table: "ClientCreditRequests",
                newName: "ProjectType");

            migrationBuilder.RenameColumn(
                name: "DateOfAssigment",
                table: "ClientCreditRequests",
                newName: "DateOfAsigment");

            migrationBuilder.RenameColumn(
                name: "ClientEntityId",
                table: "ClientCreditRequests",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "AssignedPhoneNumber",
                table: "ClientCreditRequests",
                newName: "AsignedPhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCreditRequests_RequestTypeEntityId",
                table: "ClientCreditRequests",
                newName: "IX_ClientCreditRequests_RequestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCreditRequests_ClientEntityId",
                table: "ClientCreditRequests",
                newName: "IX_ClientCreditRequests_ClientId");

            migrationBuilder.RenameColumn(
                name: "AddressTypeEntityId",
                table: "Addresses",
                newName: "NumberId");

            migrationBuilder.RenameColumn(
                name: "AddressNumberEntityId",
                table: "Addresses",
                newName: "AddressType");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AddressTypeEntityId",
                table: "Addresses",
                newName: "IX_Addresses_NumberId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RequestType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Exterior",
                table: "AddressNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Colonia",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressNumbers_NumberId",
                table: "Addresses",
                column: "NumberId",
                principalTable: "AddressNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_Clients_ClientId",
                table: "ClientCreditRequests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_RequestType_RequestTypeId",
                table: "ClientCreditRequests",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalReferences_PhoneNumbers_PhoneNumberId",
                table: "PersonalReferences",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PhoneType_PhoneTypeId",
                table: "PhoneNumbers",
                column: "PhoneTypeId",
                principalTable: "PhoneType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
