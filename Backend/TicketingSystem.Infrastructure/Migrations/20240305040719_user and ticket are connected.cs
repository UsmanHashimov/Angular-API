using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userandticketareconnected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Organisator",
                table: "Tickets",
                newName: "OrganisatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets",
                column: "OrganisatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_OrganisatorId",
                table: "Tickets",
                column: "OrganisatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_OrganisatorId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OrganisatorId",
                table: "Tickets",
                newName: "Organisator");
        }
    }
}
