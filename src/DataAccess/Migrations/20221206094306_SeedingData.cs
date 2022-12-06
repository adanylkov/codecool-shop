using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Department", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Hardware", "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display.", "Tablet" },
                    { 2, "Hardware", "A laptop computer is a battery- or AC-powered personal computer", "Laptop" },
                    { 3, "Hardware", "A Graphics card is an expansion card which generates a feed of output images to a display device, such as a computer monitor.", "Graphics card" },
                    { 4, "Hardware", "a telephone with access to a cellular radio system so it can be used over a wide area, without a physical connection to a network.", "Mobile Phone" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Digital content and services", "Amazon" },
                    { 2, "Computers", "Lenovo" },
                    { 3, "Computers", "Asus" },
                    { 4, "Mobile Phones", "Samsung" },
                    { 5, "Mobile Phones and Computers", "Apple" },
                    { 6, "Graphics card ", "GeForce" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Currency", "DefaultPrice", "Description", "Name", "ProductCategoryId", "SupplierId" },
                values: new object[,]
                {
                    { 1, "USD", 49.9m, "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", "Amazon Fire", 1, 1 },
                    { 2, "USD", 479.0m, "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", "Lenovo IdeaPad Miix 700", 1, 2 },
                    { 3, "USD", 89.0m, "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", "Amazon Fire HD 8", 1, 1 },
                    { 4, "USD", 650.0m, "Bristling with high-refresh rate displays and competitive GPUs, ultra-durable TUF Gaming laptop deliver a reliable portable gaming experience to a wide audience of gamers.", "ASUS TUF Gaming", 2, 3 },
                    { 5, "USD", 510.0m, "The Nvidia GeForce RTX 3070 is a fast desktop graphics card based on the Ampere architecture", "Geforce RTX 3070", 3, 6 },
                    { 6, "USD", 610.0m, "Samsung Galaxy S22, the most affordable device in the company's 2022 flagship series, has flown under the radar", "Samsung Galaxy S22", 4, 4 },
                    { 7, "USD", 1115.0m, "Iphone 14 has A15 Bionic, with a 5‑core GPU, powers all the latest features and makes graphically intense games and AR apps feel ultrafluid.", "Iphone 14", 4, 5 },
                    { 8, "USD", 999.0m, "The ASUS ROG Phone 6 is an Android gaming smartphone made by Asus", "ASUS ROG Phone 6", 4, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
