using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Data_Transfer_Objects;
using oai_poc_backend.Data_Transfer_Objects.From_server;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;
using System.Security.Claims;

namespace oai_poc_backend.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateController : ControllerBase
    {
        private readonly GenericRepository<TemplateModel> _genericRepository;
        private readonly ITemplateRepository _templateRepository;
        public TemplateController(GenericRepository<TemplateModel> genericRepository, ITemplateRepository templateRepository)
        {
            _genericRepository = genericRepository;
            _templateRepository = templateRepository;
        }

        [HttpPost("post-template")]
        public async Task<IActionResult> AddTemplateAsync(TemplateDto template)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User could not be authenticated. Please log in and try again." });
            }
            else
            {
                TemplateModel newTemplate = new(template);
                newTemplate.UserId = userId;
                try
                {
                    await _genericRepository.Add(newTemplate);
                    return StatusCode(201, new { message = "Template was successfully added" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { errorMessage = "Internal server error while saving template", errorDetails = ex.Message });
                }
            }
        }

        [HttpGet("getTemplates")]
        public async Task<IActionResult> GetTemplatesForUserAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User could not be authenticated. Please log in and try again." });
            }
            else
            {
                try
                {
                    List<TemplateModel> userTemplates = await _templateRepository.GetAllTemplatesForUserAsync(userId);
                    List<TemplateServerDto> userTemplateDtos = userTemplates.Select(ut => new TemplateServerDto(ut)).ToList();
                    return Ok(userTemplateDtos);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { errorMessage = ex.Message });
                }

            }
        }

    }
}
