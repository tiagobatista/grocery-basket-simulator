# grocery-basket-simulator
A mini grocery basket simulator with connection to an in-memory SQL Server database

A program and associated unit tests that can price a basket of goods, accounting for special offers. The goods that can be purchased, which are all priced in EUR, are:

Soup – 65c per tin
Bread – 80c per loaf
Milk – €1.30 per bottle
Apples – €1.00 per bag
Current special offers are:

Apples have 10% off their normal price this week
Buy 2 tins of soup and get a loaf of bread for half price
The program should accept a list of items in the basket and output the subtotal, the special offer discounts and the final price.

Input should be via the command line in the form PriceBasket item1 item2 item3 ...

For example: PriceBasket Apples Milk Bread

Output should be to the console, for example:

Subtotal: €3.10 Apples 10% off: -10c Total: €3.0

If no special offers are applicable, the code should output:

Subtotal: €1.30 (no offers available) Total: €1.30
