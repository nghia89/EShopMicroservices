using Buildingblocks.CQRS;
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) :
            IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.id,cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException(request.id);
            }

            return new GetProductByIdResult(product);
        }
    }
} 
