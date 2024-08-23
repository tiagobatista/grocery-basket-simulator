public class BasketService : IBasketService
{
    private IItemRepository _itemRepository;

    public BasketService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void AddItemToBasket(string itemName, Basket basket)
    {
        var item = _itemRepository.GetItem(itemName);

        if (item is not null)
        {
            basket.AddItem(item.Name);
            return;
        }

        throw new ItemDoesNotExistException($"The item {itemName} does not exist in the store!");
    }

    public string CalculateTotalBasketPrice(Basket basket)
    {
        decimal total = 0;

        foreach (var basketItem in basket.Items)
        {
            var item = _itemRepository.GetItem(basketItem.Key) ?? throw new ItemDoesNotExistException($"Item {basketItem.Key} from basket does not exist in stock!");

            total += item.Price * basketItem.Value;
        }

        return $"Total basket price is {total:#.##}€";
    }
}