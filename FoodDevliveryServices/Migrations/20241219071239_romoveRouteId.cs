using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDevliveryServices.Migrations
{
    /// <inheritdoc />
    public partial class romoveRouteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_DeliveryRoutes_RouteId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_RouteId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Drivers");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ShopId",
                table: "Deliveries",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Shops_ShopId",
                table: "Deliveries",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Shops_ShopId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_ShopId",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_RouteId",
                table: "Drivers",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_DeliveryRoutes_RouteId",
                table: "Drivers",
                column: "RouteId",
                principalTable: "DeliveryRoutes",
                principalColumn: "Id");
        }
    }
}
