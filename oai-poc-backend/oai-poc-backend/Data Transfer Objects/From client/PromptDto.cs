using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace oai_poc_backend.Data_Transfer_Objects
{
    public class PromptDto
    {

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Input is required")]
        [MinLength(1, ErrorMessage = "Input cannot be empty")]
        public string FreeText { get; set; } = null!;

        [Required(ErrorMessage = "Product ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be greater than 0")]
        [DefaultValue(0)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ai model url is required")]
        [MinLength(1, ErrorMessage = "Ai model url cannot be empty")]
        public string AiModelUrl { get; set; } = null!;

        [DefaultValue(null)]
        public int? TemplateId { get; set; }

        public List<SettingDto> Settings { get; set; } = new();
        public List<OptionDto> Options { get; set; } = new();

    }
}
