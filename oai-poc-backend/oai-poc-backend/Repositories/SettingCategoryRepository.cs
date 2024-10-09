using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public class SettingCategoryRepository : ISettingCategoryRepository
    {
        public AppDbContext Context { get; set; }

        public SettingCategoryRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<SettingCategory>> GetAllSettingCategoriesWithSettingsAsync()
        {
            return await Context.SettingCategories.Include(sc => sc.Settings).ToListAsync();
        }
    }
}
