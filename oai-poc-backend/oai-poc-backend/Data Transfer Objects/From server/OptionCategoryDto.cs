using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects.From_server
{
    /// <summary>
    /// Simplified DTO-model for option categories.
    /// Each of it's options is also projected into a simplified DTO for one specific option.
    /// For usage when getting option categories.
    /// </summary>
    public class OptionCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public List<OptionServerDto> Options { get; set; } = new();

        public OptionCategoryDto(OptionCategory optionCategory)
        {
            Id = optionCategory.Id;
            Name = optionCategory.Name;
            ImageUrl = optionCategory.ImageUrl;
            Options = optionCategory.Options.Select(s => new OptionServerDto(s)).ToList();
        }
    }
}
