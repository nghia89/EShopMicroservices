using Buildingblocks.Exceptions;

namespace Basket.API.Exceptions
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(Guid id) : base("Basket", id)
        {

        }
        public BasketNotFoundException(string id) : base("Basket", id)
        {

        }
    }
  
}
