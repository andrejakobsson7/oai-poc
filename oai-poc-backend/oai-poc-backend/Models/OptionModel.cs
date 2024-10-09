using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class OptionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("detailed_description")]
        public string DetailedDescription { get; set; } = null!;

        [Column("token_value")]
        public int TokenValue { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("option_category_id")]
        public int OptionCategoryId { get; set; }

        //Navigation properties
        public OptionCategory? OptionCategory { get; set; }
    }
}
