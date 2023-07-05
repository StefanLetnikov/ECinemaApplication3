using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders");

            migrationBuilder.DropIndex(
                name: "IX_TicketInOrders_TicketId",
                table: "TicketInOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketInOrders",
                table: "TicketInOrders",
                columns: new[] { "TicketId", "OrderId" });
        }
    }
}
