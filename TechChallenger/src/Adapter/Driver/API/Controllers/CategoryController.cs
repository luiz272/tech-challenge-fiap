using Application.UseCases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
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
    }
}