using OneReview.API.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ProductService>();
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();