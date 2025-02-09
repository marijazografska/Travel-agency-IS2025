using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class models2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItineraryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itinerary_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedRoute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItineraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedRoute_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThingsToDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_PlannedRoute_PlannedRouteId",
                        column: x => x.PlannedRouteId,
                        principalTable: "PlannedRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PlannedRouteId",
                table: "Activity",
                column: "PlannedRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Itinerary_ProductId",
                table: "Itinerary",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedRoute_ItineraryId",
                table: "PlannedRoute",
                column: "ItineraryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "PlannedRoute");

            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "Products");
        }
    }
}
