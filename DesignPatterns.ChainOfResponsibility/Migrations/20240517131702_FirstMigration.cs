using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesignPatterns.ChainOfResponsibility.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    ingredient_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredient_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.ingredient_id);
                });

            migrationBuilder.CreateTable(
                name: "pizza_order",
                columns: table => new
                {
                    pizza_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizza_base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pizza_dough = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receipt_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza_order", x => x.pizza_id);
                });

            migrationBuilder.CreateTable(
                name: "order_ingredient",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    ingredient_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_ingredient", x => new { x.order_id, x.ingredient_id });
                    table.ForeignKey(
                        name: "FK_order_ingredient_ingredient_ingredient_id",
                        column: x => x.ingredient_id,
                        principalTable: "ingredient",
                        principalColumn: "ingredient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_ingredient_pizza_order_order_id",
                        column: x => x.order_id,
                        principalTable: "pizza_order",
                        principalColumn: "pizza_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    receipt_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receipt_cost = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.receipt_id);
                    table.ForeignKey(
                        name: "FK_receipt_pizza_order_order_id",
                        column: x => x.order_id,
                        principalTable: "pizza_order",
                        principalColumn: "pizza_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "ingredient_id", "ingredient_name" },
                values: new object[,]
                {
                    { 1L, "CookedProsciutto" },
                    { 2L, "Mushrooms" },
                    { 3L, "Prosciutto" },
                    { 4L, "Pineapple" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_ingredient_ingredient_id",
                table: "order_ingredient",
                column: "ingredient_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_order_id",
                table: "receipt",
                column: "order_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_ingredient");

            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "pizza_order");
        }
    }
}
