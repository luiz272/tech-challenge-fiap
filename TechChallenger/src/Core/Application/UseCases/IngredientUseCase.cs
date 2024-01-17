using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class IngredientUseCase : IIngredientUseCase
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientUseCase(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public IEnumerable<Ingredient> GetAllIngredients()
    {
        return _ingredientRepository.GetAll();
    }

}