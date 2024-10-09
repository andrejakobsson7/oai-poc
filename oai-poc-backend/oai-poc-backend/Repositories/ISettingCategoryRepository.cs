using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public interface ISettingCategoryRepository
    {
        public AppDbContext Context { get; set; }

        public Task<List<SettingCategory>> GetAllSettingCategoriesWithSettingsAsync();
    }
}
