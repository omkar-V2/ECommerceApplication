using System.Text.Json.Serialization;
using ECommerceApplication.Services.Interfaces;
using ECommerceApplication.Services.Services;

namespace ECommerceApplication.API;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
         
        builder.Services.AddHttpClient();

        // Add services to the container.
        //.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ISalesService, SalesService>();

        builder.Services.AddHttpClient<IProductService, ProductService>(client =>
        {
            client.BaseAddress = new Uri("https://fakestoreapi.com/products/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
