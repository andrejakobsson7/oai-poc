using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class OptionCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("image_url")]
        public string ImageUrl { get; set; } = null!;

        //Navigation properties
        public List<OptionModel> Options { get; set; } = new();
    }
}
