
using Buildingblocks.CQRS;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StorebasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StorebasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().NotEmpty()
                .WithMessage("Cart can nots be null");
            RuleFor(x => x.Cart.UserName).NotEmpty()
    .WithMessage("UserName í required");
        }
    }

    public class StoreBasketCommandHandler(IBasketRepository repository)
         : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //await DeductDiscount(command.Cart, cancellationToken);

        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }

    //private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    //{
    //    // Communicate with Discount.Grpc and calculate lastest prices of products into sc
    //    foreach (var item in cart.Items)
    //    {
    //        var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
    //        item.Price -= coupon.Amount;
    //    }
    //}
}
}
