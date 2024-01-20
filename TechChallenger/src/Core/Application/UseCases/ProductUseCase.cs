using Application.ViewModel;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases;

public class ProductUseCase : IProductUseCase
{
    private readonly IProductRepository _productRepository;

    public ProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public object CreateProduct(CreateProductViewModel product)
    {
        var newProduct = Product.CreateProduct(
            product.Name,
            product.CategoryId,
            product.Price,
            product.Description,
            product.ImageUrl,
            product.Estimative
        );

        _productRepository.Add(newProduct);

        return newProduct;
    }

    public object UpdateProduct(Product product)
    {
        _productRepository.Update(product);

        return product;
    }

    public void RemoveProduct(Guid id)
    {
        var product = _productRepository.GetByIdAsync(id);
        _productRepository.Remove(product);
    }
}