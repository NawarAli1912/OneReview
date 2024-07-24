using Microsoft.AspNetCore.Mvc;

using OneReview.API.Domain;
using OneReview.API.Services;

namespace OneReview.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        var product = request.ToDomain();

        _productService.Create(product);

        var response = ProductResponse.FromDomain(product);

        return CreatedAtAction(
            nameof(Get),
            new { id = response.Id },
            response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var product = _productService.Get(id);

        return product is null ?
            Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Product with id: {id} doesn't exist.") :
            Ok(
            ProductResponse.FromDomain(product)
            );
    }
}

public record CreateProductRequest(string Name, string Category, string SubCategory)
{
    public Product ToDomain()
    {
        return new Product
        {
            Name = Name,
            Category = Category,
            SubCategory = SubCategory
        };
    }
}

public record ProductResponse(Guid Id, string Name, string Category, string SubCategory)
{
    public static ProductResponse FromDomain(Product product)
    {
        return new ProductResponse(product.Id, product.Name, product.Category, product.SubCategory);
    }
}
