using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JSCRUD.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Apple MacBook Air 13\"", 1099.99 },
                    { 2, "Dell XPS 15", 1499.99 },
                    { 3, "Logitech MX Master 3S Mouse", 99.989999999999995 },
                    { 4, "Keychron K8 Mechanical Keyboard", 89.989999999999995 },
                    { 5, "Samsung 27\" 4K Monitor", 329.99000000000001 },
                    { 6, "Sony WH-1000XM5 Headphones", 399.99000000000001 },
                    { 7, "Apple iPad Air", 599.99000000000001 },
                    { 8, "Kindle Paperwhite", 149.99000000000001 },
                    { 9, "Nintendo Switch OLED", 349.99000000000001 },
                    { 10, "GoPro HERO12 Black", 399.99000000000001 },
                    { 11, "Anker 65W USB-C Charger", 45.990000000000002 },
                    { 12, "SanDisk 1TB Portable SSD", 119.98999999999999 },
                    { 13, "Fitbit Charge 6", 159.94999999999999 },
                    { 14, "Ninja Air Fryer 5-Qt", 109.98999999999999 },
                    { 15, "Dyson V11 Cordless Vacuum", 569.99000000000001 },
                    { 16, "Instant Pot Duo 7-in-1", 99.950000000000003 },
                    { 17, "LEGO Star Wars X-Wing Set", 239.99000000000001 },
                    { 18, "YETI Rambler 30oz Tumbler", 38.0 },
                    { 19, "Adidas Ultraboost Running Shoes", 189.99000000000001 },
                    { 20, "Patagonia Nano Puff Jacket", 239.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 20);
        }
    }
}
