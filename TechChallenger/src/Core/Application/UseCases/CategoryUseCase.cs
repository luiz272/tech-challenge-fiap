using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class CategoryUseCase : ICategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUseCase(ICategoryRepository CategoryRepository)
    {
        _categoryRepository = CategoryRepository;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }

}