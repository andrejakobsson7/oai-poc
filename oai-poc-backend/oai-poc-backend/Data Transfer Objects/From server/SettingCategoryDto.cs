using oai_poc_backend.Data_Transfer_Objects.From_server;
using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects
{
    /// <summary>
    /// Simplified DTO-model for setting categories.
    /// Each of it's settings is also projected into a simplified DTO for one specific setting.
    /// For usage when getting option settings.
    /// </summary>
    public class SettingCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public List<SettingServerDto> Settings { get; set; } = new();

        public SettingCategoryDto(SettingCategory settingCategory)
        {
            Id = settingCategory.Id;
            Name = settingCategory.Name;
            ImageUrl = settingCategory.ImageUrl;
            Settings = settingCategory.Settings.Select(s => new SettingServerDto(s)).ToList();
        }
    }
}
