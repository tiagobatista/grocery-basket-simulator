public interface IBasketService
{
    public void AddItemToBasket(string itemName, Basket basket);

    public string CalculateTotalBasketPrice(Basket basket);
}