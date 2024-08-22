public interface IItemRepository
{
    public Item? GetItem(string itemName);

    public bool SaveItem(string itemName, decimal price);
}