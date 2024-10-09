using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects.From_server
{
    /// <summary>
    /// DTO-model for one option. Exclude relation to it's category to avoid cycles.
    /// For usage when getting option categories with included options.
    /// </summary>
    public class OptionServerDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? DetailedDescription { get; set; }

        public string CategoryName { get; set; }

        public OptionServerDto(OptionModel option)
        {
            Id = option.Id;
            Name = option.Name;
            ImageUrl = option.ImageUrl;
            DetailedDescription = option.DetailedDescription;
            if (option.OptionCategory != null)
            {
                CategoryName = option.OptionCategory.Name;
            }
        }
    }
}
