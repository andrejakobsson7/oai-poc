using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class StatusModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        //Navigation properties
        public List<PromptModel> Prompts { get; set; } = new();
    }
}
