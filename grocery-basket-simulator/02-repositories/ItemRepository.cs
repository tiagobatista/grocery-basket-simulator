public class ItemRepository(AppDbContext context) : IItemRepository
{
    private readonly AppDbContext _context = context;

    public Item? GetItem(string itemName)
    {
        var normalizedItemName = ItemHelpers.NormalizeItemName(itemName);

        var item = _context
            .Items
            .FirstOrDefault(i => string.Equals(normalizedItemName, i.Name));

        return item;
    }

    public bool SaveItem(string itemName, decimal price)
    {
        var normalizedItemName = ItemHelpers.NormalizeItemName(itemName);

        var itemExists = _context
            .Items
            .Any(i => string.Equals(normalizedItemName, i.Name));

        if (!itemExists)
        {
            _context.Items.Add(new Item(normalizedItemName, price));
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}