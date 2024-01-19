using Domain.Entities;

namespace Application.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<Product> GetAllProducts();
        object CreateProduct(Product product);
        object UpdateProduct(Product product);
        void RemoveProduct(Guid id);
    }
}