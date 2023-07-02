using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Web.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieName = table.Column<string>(nullable: false),
                    MovieDescription = table.Column<string>(nullable: false),
                    MovieRating = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketInShoppingCarts",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false),
                    ShoppingCartId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketInShoppingCarts", x => new { x.TicketId, x.ShoppingCartId });
                    table.ForeignKey(
                        name: "FK_TicketInShoppingCarts_Tickets_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketInShoppingCarts_ShoppingCarts_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_OwnerId",
                table: "ShoppingCarts",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TicketInShoppingCarts_ShoppingCartId",
                table: "TicketInShoppingCarts",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketInShoppingCarts");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
