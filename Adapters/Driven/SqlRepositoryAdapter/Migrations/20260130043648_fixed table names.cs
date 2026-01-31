using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlRepositoryAdapter.Migrations
{
    /// <inheritdoc />
    public partial class fixedtablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypeEntity_AddressTypeEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_ProjectTypeEntity_ProjectTypeEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypeEntity",
                table: "ProjectTypeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTypeEntity",
                table: "AddressTypeEntity");

            migrationBuilder.RenameTable(
                name: "ProjectTypeEntity",
                newName: "ProjectType");

            migrationBuilder.RenameTable(
                name: "AddressTypeEntity",
                newName: "AddressType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressType",
                table: "AddressType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressType_AddressTypeEntityId",
                table: "Addresses",
                column: "AddressTypeEntityId",
                principalTable: "AddressType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_ProjectType_ProjectTypeEntityId",
                table: "ClientCreditRequests",
                column: "ProjectTypeEntityId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressType_AddressTypeEntityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCreditRequests_ProjectType_ProjectTypeEntityId",
                table: "ClientCreditRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressType",
                table: "AddressType");

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypeEntity");

            migrationBuilder.RenameTable(
                name: "AddressType",
                newName: "AddressTypeEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypeEntity",
                table: "ProjectTypeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTypeEntity",
                table: "AddressTypeEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypeEntity_AddressTypeEntityId",
                table: "Addresses",
                column: "AddressTypeEntityId",
                principalTable: "AddressTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCreditRequests_ProjectTypeEntity_ProjectTypeEntityId",
                table: "ClientCreditRequests",
                column: "ProjectTypeEntityId",
                principalTable: "ProjectTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
