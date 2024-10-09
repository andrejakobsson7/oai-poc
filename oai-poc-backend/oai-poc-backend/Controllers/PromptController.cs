using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Data_Transfer_Objects;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;
using System.Security.Claims;

namespace oai_poc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //NEW SCHOOL
    public class PromptController(GenericRepository<PromptModel> genericRepository) : ControllerBase
    {

        private readonly GenericRepository<PromptModel> _genericRepository = genericRepository;

        [HttpPost("post-prompt")]
        public async Task<IActionResult> AddPromptAsync(PromptDto prompt)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { errorMessage = "User could not be authenticated. Please log in and try again." });
            }
            else
            {
                PromptModel newPrompt = new(prompt);
                newPrompt.UserId = userId;
                try
                {
                    await _genericRepository.Add(newPrompt);
                    //Create model that should be sent to the ai model.
                    ImageGenerationDto imageGenerationDto = new(newPrompt, prompt);
                    //TODO: Send to python
                    //TODO: await response from python before returning to client.
                    return StatusCode(201, new { message = "Prompt was successfully added. Waiting for image generation.", promptId = newPrompt.Id, pythonModel = imageGenerationDto });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { errorMessage = "Internal server error while saving prompt", errorDetails = ex.Message });
                }
            }
        }
    }
}
