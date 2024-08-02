
namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository basketRepository, IDistributedCache cache)
        : ICachedBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
    {
        await basketRepository.DeleteBasket(userName);
        await cache.RemoveAsync(userName, cancellationToken);
        return true;
    }

    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken)
    {
        var cacheBasket = await cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cacheBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket);

        var basket = await basketRepository.GetBasket(userName, cancellationToken);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
    {
        await basketRepository.StoreBasket(basket, cancellationToken);
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }
}
}
