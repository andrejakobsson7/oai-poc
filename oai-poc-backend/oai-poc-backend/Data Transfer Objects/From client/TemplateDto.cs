using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace oai_poc_backend.Data_Transfer_Objects
{
    /// <summary>
    /// DTO-model for template.
    /// For usage when saving a template.
    /// </summary>
    public class TemplateDto
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
        public List<SettingDto> Settings { get; set; } = new();
        public List<OptionDto> Options { get; set; } = new();
    }
}
