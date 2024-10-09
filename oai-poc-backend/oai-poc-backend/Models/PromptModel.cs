using oai_poc_backend.Data_Transfer_Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class PromptModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("free_text")]
        public string FreeText { get; set; } = null!;

        [Column("created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Column("user_id")]
        public string UserId { get; set; } = null!;

        [Column("product_id")]
        public int? ProductId { get; set; }

        [Column("status_id")]
        public int StatusId { get; set; } = 1;

        [Column("template_id")]
        public int? TemplateId { get; set; }

        //Navigation properties
        public ApplicationUser? User { get; set; }
        public ProductModel? Product { get; set; }
        public List<PromptOption> PromptOptions { get; set; } = new();
        public List<PromptSetting> PromptSettings { get; set; } = new();
        public StatusModel? Status { get; set; }
        public TemplateModel? Template { get; set; }

        public PromptModel(PromptDto promptDto)
        {
            Name = promptDto.Name;
            FreeText = promptDto.FreeText;
            ProductId = promptDto.ProductId;
            TemplateId = promptDto.TemplateId;
            PromptOptions = promptDto.Options.Select(o => new PromptOption(o)).ToList();
            PromptSettings = promptDto.Settings.Select(s => new PromptSetting(s)).ToList();
        }
        public PromptModel()
        {

        }
    }

}
