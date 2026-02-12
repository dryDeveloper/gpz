using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlRepositoryAdapter.Migrations
{
    /// <inheritdoc />
    public partial class updatedusercomposedentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditRequestNumber",
                table: "ClientCreditRequests",
                newName: "RequestNumber");

            migrationBuilder.RenameColumn(
                name: "Colonia",
                table: "Addresses",
                newName: "Colony");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestNumber",
                table: "ClientCreditRequests",
                newName: "CreditRequestNumber");

            migrationBuilder.RenameColumn(
                name: "Colony",
                table: "Addresses",
                newName: "Colonia");
        }
    }
}
