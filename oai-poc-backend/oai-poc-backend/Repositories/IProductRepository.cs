using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public interface IProductRepository
    {
        public AppDbContext Context { get; set; }
        public Task<List<ProductModel>> GetAllProductsForOrganizationIdAsync(int organizationId);
    }
}
