using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Models;

namespace oai_poc_backend.Database
{
    //Change from identity user to application user
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<OptionCategory> OptionCategories { get; set; }
        public DbSet<OptionModel> Options { get; set; }
        public DbSet<OrganizationModel> Organizations { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<PromptModel> Prompts { get; set; }
        public DbSet<PromptOption> PromptOptions { get; set; }
        public DbSet<PromptSetting> PromptSettings { get; set; }
        public DbSet<SettingCategory> SettingCategories { get; set; }
        public DbSet<SettingModel> Settings { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
        public DbSet<TemplateModel> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedOrganizationData(modelBuilder);
            SeedProductData(modelBuilder);
            SeedStatuses(modelBuilder);
            SeedSettingCategories(modelBuilder);
            SeedSettings(modelBuilder);
            SeedOptionCategories(modelBuilder);
            SeedOptions(modelBuilder);
        }

        private void SeedOrganizationData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationModel>().HasData(
                new OrganizationModel
                {
                    Id = 1,
                    OrganizationNumber = 5569426710,
                    Name = "Nocco AB"
                },
                new OrganizationModel
                {
                    Id = 2,
                    OrganizationNumber = 5560736356,
                    Name = "Panduro Hobby Aktiebolag"
                });
        }
        private void SeedProductData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    Id = 1,
                    Name = "Blue Raspberry",
                    Description = "The image features a product from the brand Tyngre, specifically their Blue Raspberry flavored supplement. The packaging is a cylindrical container with a sleek and modern design. The primary color of the container is a deep blue, which is complemented by white and light blue accents. At the top of the container, the Tyngre logo is prominently displayed in bold white letters. Below the logo, the flavor “Blue Raspberry” is clearly indicated in a stylish font, also in white. The background of the label features a subtle gradient from dark blue at the top to a lighter blue at the bottom, giving it a dynamic and appealing look.\r\n\r\nThe container also includes additional text and branding elements, such as nutritional information and product benefits, which are written in smaller fonts and positioned around the main logo and flavor text. The overall design is clean and visually appealing, aimed at attracting fitness enthusiasts and individuals looking for high-quality nutritional supplements.\r\n\r\nThe image is well-lit, highlighting the glossy finish of the container and making the colors pop. The product is centered in the frame, with no other objects or distractions in the background, ensuring that the focus remains solely on the supplement container.",
                    AIModelUrl = "https://tyngre.centracdn.net/client/dynamic/images/634_ed258f9eaf-se_tyngre_blueraspberry_240821_produktbild_1000x1340-08-full.jpg",
                    OrganizationId = 1,
                    TokenValue = 200,
                    Created = DateTime.Now,
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Green Apple",
                    Description = "The image features a Tyngre Green Apple supplement can. The can is cylindrical with a glossy finish and a modern design. The primary color is a vibrant green, complemented by white and light green accents. The Tyngre logo is prominently displayed at the top in bold white letters. Below the logo, the flavor “Green Apple” is clearly indicated in a stylish white font. The background of the label features a subtle gradient from dark green at the top to a lighter green at the bottom, giving it a dynamic and appealing look. Additional text and branding elements, such as nutritional information and product benefits, are written in smaller fonts around the main logo and flavor text. The can is well-lit, highlighting its glossy finish and making the colors pop. The product is centered in the frame, with no other objects or distractions in the background, ensuring the focus remains solely on the supplement can.",
                    AIModelUrl = "https://tyngre.centracdn.net/client/dynamic/images/69_639bd80db9-se_nocco_single_1000x1340_green_apple_60png-20-full.jpg",
                    OrganizationId = 1,
                    TokenValue = 200,
                    Created = DateTime.Now,
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Akrylgarn",
                    Description = "The image features a skein of yarn from Panduro. The yarn is soft and fluffy, with a chunky texture that suggests it is likely a bulky weight yarn. The color is a vibrant, solid red, giving it a rich and warm appearance. The yarn is neatly wound into a skein, showcasing its thickness and the evenness of the fibers. The fibers appear to be smooth and slightly shiny, indicating a high-quality material, possibly a blend of wool and synthetic fibers. The label wrapped around the skein includes branding and product information, but the text is not clearly visible in the image. The overall presentation of the yarn is clean and appealing, making it suitable for cozy projects like scarves, hats, or blankets.",
                    AIModelUrl = "https://static.panduro.com/ArticleImages/565x565/320205_01.webp",
                    OrganizationId = 2,
                    TokenValue = 200,
                    Created = DateTime.Now,
                },
                new ProductModel
                {
                    Id = 4,
                    Name = "Akrylgarn",
                    Description = "The product is a flat acrylic paintbrush designed for hobby and craft use. It features a wide, flat brush head with synthetic bristles that are ideal for smooth and even application of acrylic paints. The bristles are densely packed and have a slight stiffness, providing good control and precision. The brush head is attached to a sturdy, silver-colored ferrule that securely holds the bristles in place. The handle is made of wood and is painted in a vibrant blue color. It has a smooth, glossy finish and is ergonomically shaped for a comfortable grip. The handle tapers slightly towards the end, making it easy to maneuver during painting. The overall length of the brush is approximately 32 cm, making it suitable for both detailed work and covering larger areas. This brush is perfect for artists and hobbyists looking for a reliable tool for their acrylic painting projects.",
                    AIModelUrl = "https://static.panduro.com/ArticleImages/565x565/517034_01.webp",
                    OrganizationId = 2,
                    TokenValue = 200,
                    Created = DateTime.Now,
                });
        }
        private void SeedStatuses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusModel>().HasData(
                new StatusModel
                {
                    Id = 1,
                    Name = "Received"
                },
                new StatusModel
                {
                    Id = 2,
                    Name = "In progress"
                },
                new StatusModel
                {
                    Id = 3,
                    Name = "Completed"
                },
                new StatusModel
                {
                    Id = 4,
                    Name = "Failed"
                }
                );
        }
        private void SeedSettingCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingCategory>().HasData(
                new SettingCategory
                {
                    Id = 1,
                    Name = "Aspect Ratio",
                    ImageUrl = "https://static.thenounproject.com/png/2221964-200.png"
                });
        }
        private void SeedSettings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingModel>().HasData(

                new SettingModel
                {
                    Id = 1,
                    Name = "16:9",
                    ImageUrl = "https://cdn-icons-png.flaticon.com/512/3172/3172457.png",
                    SettingCategoryId = 1
                },
                new SettingModel
                {
                    Id = 2,
                    Name = "4:3",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVIGEIuRzfjOoqg1ITa7FRRY72TJZtgjU3TA&s",
                    SettingCategoryId = 1
                });
        }
        private void SeedOptionCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OptionCategory>().HasData(
                new OptionCategory
                {
                    Id = 1,
                    Name = "Style",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8SsbiKhqQjjlndxJfA_Vq0EiCtLCKNQvfFw&s"
                });
        }
        private void SeedOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OptionModel>().HasData(
                new OptionModel
                {
                    Id = 1,
                    Name = "Cartoon",
                    DetailedDescription = "Create an image with simplified, exaggerated features, bold outlines, and vibrant colors. Characters should have expressive faces and dynamic poses, with a playful and whimsical aesthetic",
                    TokenValue = 150,
                    ImageUrl = "https://i.pinimg.com/564x/13/95/9a/13959adfbc9c48213e74ee6e0dc4f519.jpg",
                    Active = true,
                    OptionCategoryId = 1,

                },
                new OptionModel
                {
                    Id = 2,
                    Name = "Anime",
                    DetailedDescription = "Anime style is characterized by vibrant colors, dynamic compositions, and expressive characters. Characters often have large, emotive eyes, distinct hairstyles, and exaggerated facial expressions. Backgrounds are detailed, featuring fantastical landscapes or urban settings. The style ranges from cute and whimsical (Chibi) to dark and realistic (Seinen). Common themes include adventure, romance, and the supernatural, depicted with a sense of motion and energy.",
                    TokenValue = 150,
                    ImageUrl = "https://img.freepik.com/premium-vector/vector-young-man-anime-style-character-vector-illustration-design-manga-anime-boy_147933-12395.jpg",
                    Active = false,
                    OptionCategoryId = 1,
                }
                );
        }

    }
}
