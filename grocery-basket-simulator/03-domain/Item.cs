public class Item
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}