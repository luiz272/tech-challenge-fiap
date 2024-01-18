using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ILogger<TagsController> _logger;
        private readonly ITagUseCase _tagUseCase;

        public TagsController(ILogger<TagsController> logger, ITagUseCase tagUseCase)
        {
            _logger = logger;
            _tagUseCase = tagUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_tagUseCase.GetAllTags());
        }
        
        [HttpPost]
        public IActionResult CreateTag([FromBody] Tag tagModel)
        {
            if (tagModel == null)
            {
                return BadRequest("Invalid tag data");
            }

            try
            {
                _tagUseCase.CreateTag(tagModel);

                return Ok("Tag Criada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
    }
}