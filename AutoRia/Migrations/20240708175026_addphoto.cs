using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoRia.Migrations
{
    /// <inheritdoc />
    public partial class addphoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Crossover" },
                    { 2, "Sedan" },
                    { 3, "Universal" },
                    { 4, "Miniven" },
                    { 5, "Pickup" },
                    { 6, "Fastback" },
                    { 7, "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Archived", "CategoryId", "Description", "Discount", "ImageUrl", "Mark", "Model", "Price", "Quantity", "Year" },
                values: new object[,]
                {
                    { 1, false, 2, null, 5, "https://nextcar.ua/images/blog/484/audi-a8-2022__9_.jpg", "Audi", "A8", 19899m, 2, 2018 },
                    { 2, false, 1, null, 0, "https://stimg.cardekho.com/images/carexteriorimages/930x620/Mercedes-Benz/GLS/9791/1704772236530/front-left-side-47.jpg", "Mercedes-Benz", "GLS", 29999m, 3, 2019 },
                    { 3, false, 1, null, 0, "https://media.ed.edmunds-media.com/bmw/x5/2025/oem/2025_bmw_x5_4dr-suv_xdrive40i_fq_oem_1_600.jpg", "BMW", "X5", 14999m, 1, 2014 },
                    { 4, false, 7, null, 0, "https://images.prismic.io/carwow/2b4b884f-fa2b-40e2-9182-2d2c9450ac5b_37018-ThenewVolkswagenGolfeHybrid.jpg?auto=format&cs=tinysrgb&fit=crop&q=60&w=750", "Volkswagen", "Golf", 12999m, 6, 2015 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
