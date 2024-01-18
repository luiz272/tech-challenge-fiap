using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryUseCase CategoryUseCase)
        {
            _logger = logger;
            _categoryUseCase = CategoryUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_categoryUseCase.GetAllCategories());
        }
        
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category model)
        {
            if (model == null)
            {
                return BadRequest("Invalid category data");
            }

            try
            {
                _categoryUseCase.CreateCategory(model);

                return Ok("Categoria foi criada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category model)
        {
            if (model == null)
            {
                return BadRequest("Invalid category data");
            }

            try
            {
                _categoryUseCase.UpdateCategory(model);

                return Ok("Categoria foi criada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating tag: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult RemoveCategory(Guid id)
        {
            try
            {
                _categoryUseCase.RemoveCategory(id);

                return Ok("Categoria foi removida com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing category: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}