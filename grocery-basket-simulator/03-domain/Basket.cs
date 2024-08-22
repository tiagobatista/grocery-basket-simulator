public class Basket
{
    // <name, quantity>
    public Dictionary<string, int> Items;

    public Basket()
    {
        Items = new Dictionary<string, int>();
    }

    public void AddItem(string itemName)
    {
        if (Items.Count == 6)
        {
            throw new FullBasketException("Basket is full!");
        }

        if (!Items.TryAdd(itemName.ToLowerInvariant(), 1))
        {
            Items[itemName]++;
        }
    }
}