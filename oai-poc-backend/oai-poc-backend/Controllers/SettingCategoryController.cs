using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Data_Transfer_Objects;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;

namespace oai_poc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingCategoryController : ControllerBase
    {
        private readonly ISettingCategoryRepository _settingCategoryRepository;
        public SettingCategoryController(ISettingCategoryRepository settingCategoryRepository)
        {
            _settingCategoryRepository = settingCategoryRepository;
        }

        [HttpGet("get-setting-categories")]
        public async Task<IActionResult> GetSettingCategoriesWithSettingsAsync()
        {
            try
            {
                List<SettingCategory> settingCategories = await _settingCategoryRepository.GetAllSettingCategoriesWithSettingsAsync();
                List<SettingCategoryDto> settingCategoryDtos = settingCategories.Select(sc => new SettingCategoryDto(sc)).ToList();
                return Ok(settingCategoryDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
