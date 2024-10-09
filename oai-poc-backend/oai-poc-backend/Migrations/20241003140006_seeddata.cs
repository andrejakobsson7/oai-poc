using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace oai_poc_backend.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "organization_number",
                table: "Organizations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "OptionCategories",
                columns: new[] { "id", "image_url", "name" },
                values: new object[] { 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8SsbiKhqQjjlndxJfA_Vq0EiCtLCKNQvfFw&s", "Style" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "id", "name", "organization_number" },
                values: new object[,]
                {
                    { 1, "Nocco AB", 5569426710L },
                    { 2, "Panduro Hobby Aktiebolag", 5560736356L }
                });

            migrationBuilder.InsertData(
                table: "SettingCategories",
                columns: new[] { "id", "image_url", "name" },
                values: new object[] { 1, "https://static.thenounproject.com/png/2221964-200.png", "Aspect Ratio" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Received" },
                    { 2, "In progress" },
                    { 3, "Completed" },
                    { 4, "Failed" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "id", "active", "detailed_description", "image_url", "name", "option_category_id", "token_value" },
                values: new object[,]
                {
                    { 1, true, "Create an image with simplified, exaggerated features, bold outlines, and vibrant colors. Characters should have expressive faces and dynamic poses, with a playful and whimsical aesthetic", "https://i.pinimg.com/564x/13/95/9a/13959adfbc9c48213e74ee6e0dc4f519.jpg", "Cartoon", 1, 150 },
                    { 2, false, "Anime style is characterized by vibrant colors, dynamic compositions, and expressive characters. Characters often have large, emotive eyes, distinct hairstyles, and exaggerated facial expressions. Backgrounds are detailed, featuring fantastical landscapes or urban settings. The style ranges from cute and whimsical (Chibi) to dark and realistic (Seinen). Common themes include adventure, romance, and the supernatural, depicted with a sense of motion and energy.", "https://img.freepik.com/premium-vector/vector-young-man-anime-style-character-vector-illustration-design-manga-anime-boy_147933-12395.jpg", "Anime", 1, 150 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "ai_model_url", "created", "description", "name", "organization_id", "token_value" },
                values: new object[,]
                {
                    { 1, "https://tyngre.centracdn.net/client/dynamic/images/634_ed258f9eaf-se_tyngre_blueraspberry_240821_produktbild_1000x1340-08-full.jpg", new DateTime(2024, 10, 3, 16, 0, 5, 606, DateTimeKind.Local).AddTicks(2940), "The image features a product from the brand Tyngre, specifically their Blue Raspberry flavored supplement. The packaging is a cylindrical container with a sleek and modern design. The primary color of the container is a deep blue, which is complemented by white and light blue accents. At the top of the container, the Tyngre logo is prominently displayed in bold white letters. Below the logo, the flavor “Blue Raspberry” is clearly indicated in a stylish font, also in white. The background of the label features a subtle gradient from dark blue at the top to a lighter blue at the bottom, giving it a dynamic and appealing look.\r\n\r\nThe container also includes additional text and branding elements, such as nutritional information and product benefits, which are written in smaller fonts and positioned around the main logo and flavor text. The overall design is clean and visually appealing, aimed at attracting fitness enthusiasts and individuals looking for high-quality nutritional supplements.\r\n\r\nThe image is well-lit, highlighting the glossy finish of the container and making the colors pop. The product is centered in the frame, with no other objects or distractions in the background, ensuring that the focus remains solely on the supplement container.", "Blue Raspberry", 1, 200 },
                    { 2, "https://tyngre.centracdn.net/client/dynamic/images/69_639bd80db9-se_nocco_single_1000x1340_green_apple_60png-20-full.jpg", new DateTime(2024, 10, 3, 16, 0, 5, 606, DateTimeKind.Local).AddTicks(2993), "The image features a Tyngre Green Apple supplement can. The can is cylindrical with a glossy finish and a modern design. The primary color is a vibrant green, complemented by white and light green accents. The Tyngre logo is prominently displayed at the top in bold white letters. Below the logo, the flavor “Green Apple” is clearly indicated in a stylish white font. The background of the label features a subtle gradient from dark green at the top to a lighter green at the bottom, giving it a dynamic and appealing look. Additional text and branding elements, such as nutritional information and product benefits, are written in smaller fonts around the main logo and flavor text. The can is well-lit, highlighting its glossy finish and making the colors pop. The product is centered in the frame, with no other objects or distractions in the background, ensuring the focus remains solely on the supplement can.", "Green Apple", 1, 200 },
                    { 3, "https://static.panduro.com/ArticleImages/565x565/320205_01.webp", new DateTime(2024, 10, 3, 16, 0, 5, 606, DateTimeKind.Local).AddTicks(2998), "The image features a skein of yarn from Panduro. The yarn is soft and fluffy, with a chunky texture that suggests it is likely a bulky weight yarn. The color is a vibrant, solid red, giving it a rich and warm appearance. The yarn is neatly wound into a skein, showcasing its thickness and the evenness of the fibers. The fibers appear to be smooth and slightly shiny, indicating a high-quality material, possibly a blend of wool and synthetic fibers. The label wrapped around the skein includes branding and product information, but the text is not clearly visible in the image. The overall presentation of the yarn is clean and appealing, making it suitable for cozy projects like scarves, hats, or blankets.", "Akrylgarn", 2, 200 },
                    { 4, "https://static.panduro.com/ArticleImages/565x565/517034_01.webp", new DateTime(2024, 10, 3, 16, 0, 5, 606, DateTimeKind.Local).AddTicks(3000), "The product is a flat acrylic paintbrush designed for hobby and craft use. It features a wide, flat brush head with synthetic bristles that are ideal for smooth and even application of acrylic paints. The bristles are densely packed and have a slight stiffness, providing good control and precision. The brush head is attached to a sturdy, silver-colored ferrule that securely holds the bristles in place. The handle is made of wood and is painted in a vibrant blue color. It has a smooth, glossy finish and is ergonomically shaped for a comfortable grip. The handle tapers slightly towards the end, making it easy to maneuver during painting. The overall length of the brush is approximately 32 cm, making it suitable for both detailed work and covering larger areas. This brush is perfect for artists and hobbyists looking for a reliable tool for their acrylic painting projects.", "Akrylgarn", 2, 200 }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "id", "image_url", "name", "setting_category_id" },
                values: new object[,]
                {
                    { 1, "https://cdn-icons-png.flaticon.com/512/3172/3172457.png", "16:9", 1 },
                    { 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVIGEIuRzfjOoqg1ITa7FRRY72TJZtgjU3TA&s", "4:3", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OptionCategories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettingCategories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "organization_number",
                table: "Organizations",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
