
public class Menu(IBasketService basketService)
{

    public IBasketService _basketService = basketService;

    public void DisplayMenu()
    {

        while (true)
        {
            try
            {
                Console.WriteLine($"Introduce your articles by writting '{Constants.ExpectedInputBeggining}' followed by the items separated by spaces (Type 'e' to leave):");

                var input = Console.ReadLine();

                if (input.Equals("e"))
                {
                    break;
                }

                var basket = new Basket();

                var productList = GetProductList(input);

                foreach (var product in productList)
                {
                    _basketService.AddItemToBasket(product, basket);
                }

                var checkoutMessage = _basketService.CalculateTotalBasketPrice(basket);

                Console.WriteLine("\n\n ### Your receipt ###\n\n");
                Console.WriteLine(checkoutMessage);
                Console.WriteLine("\n\n ### End of receipt ###\n\n");
            }
            catch (ItemDoesNotExistException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FullBasketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static List<string> GetProductList(string input)
    {
        var trimmedInput = input.Trim();

        if (trimmedInput.Length == default || trimmedInput is null)
        {
            throw new InputException("Invalid start of input!");
        }

        var splittedInput = trimmedInput.Split(" ");

        var inputBeggining = splittedInput[0];

        if (!string.Equals(Constants.ExpectedInputBeggining, inputBeggining, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InputException("Invalid start of input!");
        }

        var productList = splittedInput
            .Skip(1)
            .ToList(); //skip the input beggining 'PriceBasket'

        return productList;
    }
}