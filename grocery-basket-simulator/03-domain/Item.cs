public class Item(string name, decimal price) //primary constructor
{
    public int Id { get; init; }

    public string Name { get; init; } = name; //primary constructor

    public decimal Price { get; init; } = price; //primary constructor

}