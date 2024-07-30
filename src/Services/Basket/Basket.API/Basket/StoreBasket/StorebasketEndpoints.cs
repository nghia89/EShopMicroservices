using Basket.API.Models;
using Buildingblocks.CQRS;

namespace Basket.API.Basket.StoreBasket
{
    public record StorebasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UseName);

    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StorebasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{response.UseName}", response);
            })
                .WithName("CreatProduct")
                .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("CreatProduct");
        }
    }
}
