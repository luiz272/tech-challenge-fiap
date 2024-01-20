using Application.ViewModel;
using Domain.Entities;

namespace Application.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<Product> GetAllProducts();
        object CreateProduct(CreateProductViewModel product);
        object UpdateProduct(Product product);
        void RemoveProduct(Guid id);
    }
}