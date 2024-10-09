using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public interface ITemplateRepository
    {
        public AppDbContext Context { get; set; }

        public Task<List<TemplateModel>> GetAllTemplatesForUserAsync(string userId);
    }
}
