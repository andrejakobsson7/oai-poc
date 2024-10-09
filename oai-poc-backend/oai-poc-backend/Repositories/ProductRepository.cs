using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;
using oai_poc_backend.Models;

namespace oai_poc_backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public AppDbContext Context { get; set; }
        public ProductRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<ProductModel>> GetAllProductsForOrganizationIdAsync(int organizationId)
        {
            return await Context.Products.Where(p => p.OrganizationId == organizationId).ToListAsync();
        }

    }
}
