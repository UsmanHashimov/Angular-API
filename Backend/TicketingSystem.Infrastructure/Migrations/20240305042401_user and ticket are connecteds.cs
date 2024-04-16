using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userandticketareconnecteds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TicketId",
                table: "Users",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets",
                column: "OrganisatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tickets_TicketId",
                table: "Users",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tickets_TicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TicketId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrganisatorId",
                table: "Tickets",
                column: "OrganisatorId");
        }
    }
}
