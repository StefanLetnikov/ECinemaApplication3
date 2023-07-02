using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Web.Data.Migrations
{
    public partial class TicketIamgeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieImage",
                table: "Tickets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieImage",
                table: "Tickets");
        }
    }
}
