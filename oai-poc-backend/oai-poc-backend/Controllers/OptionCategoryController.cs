using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Data_Transfer_Objects.From_server;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;

namespace oai_poc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionCategoryController : ControllerBase
    {
        private readonly IOptionCategoryRepository _optionCategoryRepository;
        public OptionCategoryController(IOptionCategoryRepository optionCategoryRepository)
        {
            _optionCategoryRepository = optionCategoryRepository;
        }

        [HttpGet("getOptioncategories")]
        public async Task<IActionResult> GetOptionCategoriesWithOptions()
        {
            try
            {
                List<OptionCategory> optionCategories = await _optionCategoryRepository.GetAllOptionCategoriesWithOptionsAsync();
                List<OptionCategoryDto> optionCategoriesDto = optionCategories.Select(oc => new OptionCategoryDto(oc)).ToList();
                return Ok(optionCategoriesDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
