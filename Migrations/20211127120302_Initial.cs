using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLaptops.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptop_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    IsAvaiable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptop_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptop__Category__CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopCartItem_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopItemId = table.Column<int>(type: "int", nullable: true),
                    PriceItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemIdInShopCart = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItem_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCartItem__Laptop__LaptopItemId",
                        column: x => x.LaptopItemId,
                        principalTable: "Laptop_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptop__CategoryId",
                table: "Laptop_",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem__LaptopItemId",
                table: "ShopCartItem_",
                column: "LaptopItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItem_");

            migrationBuilder.DropTable(
                name: "Laptop_");

            migrationBuilder.DropTable(
                name: "Category_");
        }
    }
}
