using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects.From_server
{
    /// <summary>
    /// DTO-model for one setting. Exclude relation to it's category to avoid cycles.
    /// For usage when getting option settings with included settings.
    /// </summary>
    public class SettingServerDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? CategoryName { get; set; }

        public SettingServerDto(SettingModel setting)
        {
            Id = setting.Id;
            Name = setting.Name;
            ImageUrl = setting.ImageUrl;
            if (setting.SettingCategory != null)
            {
                CategoryName = setting.SettingCategory.Name;
            }
        }
    }
}
