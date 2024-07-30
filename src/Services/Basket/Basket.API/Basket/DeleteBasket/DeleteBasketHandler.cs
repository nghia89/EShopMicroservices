using Buildingblocks.CQRS;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool ISuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User is requierd");
        }

        public class DeleteBasketHandler(IBasketRepository repository) :
            ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
        {
            public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(request.UserName, cancellationToken);
            return new DeleteBasketResult(true);
        }
    }
}
}
