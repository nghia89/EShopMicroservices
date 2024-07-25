using Basket.API.Models;
using Buildingblocks.CQRS;

namespace Basket.API.Basket.GetBasket
{

    public record GetBasketQuery(string userName):IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
