using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;
using System.Security.Claims;

namespace oai_poc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ProductController(IProductRepository productRepository, UserManager<ApplicationUser> userManager)
        {
            _productRepository = productRepository;
            _userManager = userManager;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetAllCustomProductsForUserAsync()
        {
            //Extrahera användarens org.id från claims.
            var organizationId = User.FindFirstValue("OrganizationId");
            if (organizationId == null)
            {
                return NotFound(new { errorMessage = "Organization not found" });
            }
            else
            {
                bool successfulParse = Int32.TryParse(organizationId, out int formattedOrgId);
                if (successfulParse)
                {
                    List<ProductModel> products = await _productRepository.GetAllProductsForOrganizationIdAsync(formattedOrgId);
                    return Ok(products);
                }
                else
                {
                    return StatusCode(500, new { errorMessage = "Organization ID could not be parsed. Please contact support." });
                }
            }
        }

    }
}
