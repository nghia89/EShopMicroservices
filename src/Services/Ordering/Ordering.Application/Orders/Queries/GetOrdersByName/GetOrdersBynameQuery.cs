using Buildingblocks.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public record GetOrdersByNameQuery(string name)
        : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}
