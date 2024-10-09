using oai_poc_backend.Data_Transfer_Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class TemplateModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("free_text")]
        public string? FreeText { get; set; }

        [Column("created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column("user_id")]
        public string UserId { get; set; } = null!;

        [Column("product_id")]
        public int? ProductId { get; set; }

        //Navigation properties
        public ApplicationUser? User { get; set; }
        public ProductModel? Product { get; set; }
        public List<PromptOption> PromptOptions { get; set; } = new();
        public List<PromptSetting> PromptSettings { get; set; } = new();

        public TemplateModel(TemplateDto templateDto)
        {
            Name = templateDto.Name;
            FreeText = templateDto.FreeText;
            ProductId = templateDto.ProductId;
            PromptOptions = templateDto.Options.Select(o => new PromptOption(o)).ToList();
            PromptSettings = templateDto.Settings.Select(s => new PromptSetting(s)).ToList();
        }
        public TemplateModel()
        {

        }
    }
}
