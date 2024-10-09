using oai_poc_backend.Data_Transfer_Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class PromptOption
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("option_id")]
        public int OptionId { get; set; }

        [Column("prompt_id")]
        public int? PromptId { get; set; }

        [Column("template_id")]
        public int? TemplateId { get; set; }

        //Navigation properties
        public OptionModel? Option { get; set; }
        public PromptModel? Prompt { get; set; }
        public TemplateModel? Template { get; set; }

        public PromptOption(OptionDto optionDto)
        {
            OptionId = optionDto.Id;
        }

        public PromptOption()
        {

        }

    }
}
