using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class SettingModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("setting_category_id")]
        public int SettingCategoryId { get; set; }

        //Navigation properties
        public SettingCategory? SettingCategory { get; set; }
    }
}
