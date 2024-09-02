using Basket.API.Dtos;
namespace Basket.API.Basket.CheckOutBasket
{
    public record CheckOutBasketRequest(BasketCheckoutDto BasketCheckOutDto);
    public record CheckoutBasketResponse(bool IsSuccess);
    public class CheckOutBasketEndpoints : ICarterModule
    {
        public AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckOutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await await sender.Send(command);

                var response = result.Adapt<CheckoutBasketResponse>();

                return result.Ok(response);
            }).WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("CheckoutBasket"); ;
        }
    }
}
