using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_PlannedRoute_PlannedRouteId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Itinerary_Products_ProductId",
                table: "Itinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRoute_Itinerary_ItineraryId",
                table: "PlannedRoute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedRoute",
                table: "PlannedRoute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itinerary",
                table: "Itinerary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "PlannedRoute",
                newName: "PlannedRoutes");

            migrationBuilder.RenameTable(
                name: "Itinerary",
                newName: "Itineraries");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedRoute_ItineraryId",
                table: "PlannedRoutes",
                newName: "IX_PlannedRoutes_ItineraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Itinerary_ProductId",
                table: "Itineraries",
                newName: "IX_Itineraries_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_PlannedRouteId",
                table: "Activities",
                newName: "IX_Activities_PlannedRouteId");

            migrationBuilder.AddColumn<bool>(
                name: "AlreadyhasItinerary",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedRoutes",
                table: "PlannedRoutes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itineraries",
                table: "Itineraries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_PlannedRoutes_PlannedRouteId",
                table: "Activities",
                column: "PlannedRouteId",
                principalTable: "PlannedRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itineraries_Products_ProductId",
                table: "Itineraries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRoutes_Itineraries_ItineraryId",
                table: "PlannedRoutes",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_PlannedRoutes_PlannedRouteId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Itineraries_Products_ProductId",
                table: "Itineraries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRoutes_Itineraries_ItineraryId",
                table: "PlannedRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlannedRoutes",
                table: "PlannedRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itineraries",
                table: "Itineraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AlreadyhasItinerary",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "PlannedRoutes",
                newName: "PlannedRoute");

            migrationBuilder.RenameTable(
                name: "Itineraries",
                newName: "Itinerary");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_PlannedRoutes_ItineraryId",
                table: "PlannedRoute",
                newName: "IX_PlannedRoute_ItineraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Itineraries_ProductId",
                table: "Itinerary",
                newName: "IX_Itinerary_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_PlannedRouteId",
                table: "Activity",
                newName: "IX_Activity_PlannedRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlannedRoute",
                table: "PlannedRoute",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itinerary",
                table: "Itinerary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_PlannedRoute_PlannedRouteId",
                table: "Activity",
                column: "PlannedRouteId",
                principalTable: "PlannedRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Itinerary_Products_ProductId",
                table: "Itinerary",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRoute_Itinerary_ItineraryId",
                table: "PlannedRoute",
                column: "ItineraryId",
                principalTable: "Itinerary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
