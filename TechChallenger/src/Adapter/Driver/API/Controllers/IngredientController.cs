using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly ILogger<IngredientsController> _logger;
        private readonly IIngredientUseCase _ingredientUseCase;

        public IngredientsController(ILogger<IngredientsController> logger, IIngredientUseCase ingredientUseCase)
        {
            _logger = logger;
            _ingredientUseCase = ingredientUseCase;
        }

        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(_ingredientUseCase.GetAllIngredients());
        }
    }
}