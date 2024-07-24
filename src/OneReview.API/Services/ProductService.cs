using System.Collections.Concurrent;

using OneReview.API.Domain;

namespace OneReview.API.Services;

public class ProductService
{
    private static readonly ConcurrentDictionary<Guid, Product> _productsDictionary = [];

    public ProductService()
    {
    }

    public void Create(Product product)
    {
        _productsDictionary.TryAdd(product.Id, product);
    }

    public Product? Get(Guid id)
    {
        _productsDictionary.TryGetValue(id, out var product);

        return product;

    }
}
