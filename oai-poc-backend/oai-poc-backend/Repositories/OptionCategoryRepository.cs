using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public class OptionCategoryRepository : IOptionCategoryRepository
    {
        public AppDbContext Context { get; set; }

        public OptionCategoryRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<OptionCategory>> GetAllOptionCategoriesWithOptionsAsync()
        {
            //Only include options that are active to prevent usage of deactivated ones.
            return await Context.OptionCategories.Include(oc => oc.Options.Where(o => o.Active)).ToListAsync();
        }


    }
}
