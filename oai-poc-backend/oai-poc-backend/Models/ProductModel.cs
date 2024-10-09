using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class ProductModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("ai_model_url")]
        public string AIModelUrl { get; set; } = null!;

        [Column("organization_id")]
        public int OrganizationId { get; set; }

        [Column("token_value")]
        public int TokenValue { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        //Navigation properties
        public OrganizationModel? Organization { get; set; }
        public List<TemplateModel> Templates { get; set; } = new();
        public List<PromptModel> Prompts { get; set; } = new();
    }
}
