using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        public AppDbContext Context { get; set; }
        public TemplateRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<TemplateModel>> GetAllTemplatesForUserAsync(string userId)
        {
            try
            {
                //Only include options that are active so deactivated options can't be reused when using a template.
                return await Context.Templates.Where(t => t.UserId == userId).Include(t => t.PromptOptions.Where(o => o.Option.Active)).ThenInclude(po => po.Option).
          ThenInclude(op => op.OptionCategory).Include(t => t.PromptSettings).ThenInclude(ps => ps.Setting).ThenInclude(s => s.SettingCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
