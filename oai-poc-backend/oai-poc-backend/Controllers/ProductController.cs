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

        [HttpGet("get-products")]
        public async Task<IActionResult> GetAllProductsForUserAsync()
        {
            //Hitta aktuellt användar-id
            //TODO: Lägg in organization id som custom claim!
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User could not be authenticated. Please log in and try again." });
            }
            else
            {
                //Get signed in user with the user id.
                ApplicationUser? signedInUser = await _userManager.FindByIdAsync(userId);
                if (signedInUser == null)
                {
                    //If user is not set as IdentityUser, it will not find it even though the id exists.
                    return NotFound(new { errorMessage = $"Application user with id {userId} could not be found. Please contact support to update your Discriminator from IdentityUser to ApplicationUser." });
                }
                else
                {
                    //Get products by organization id for the found user.
                    try
                    {
                        List<ProductModel> products = await _productRepository.GetAllProductsForOrganizationIdAsync(signedInUser.OrganizationId);
                        return Ok(products);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new { errorMessage = ex.Message });
                    }

                }
            }
        }

        [HttpGet("get-products-custom-login")]
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
