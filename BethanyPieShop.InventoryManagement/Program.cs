// See https://aka.ms/new-console-template for more information
using BethanyPieShop.InventoryManagement;
using BethanyPieShop.InventoryManagement.Domain.General;
using BethanyPieShop.InventoryManagement.Domain.ProducManagement;


PrintWelcome();

Utilities1.InitializeStock();

//Product.ChangeStockThreshhold(10);
//Product.StockThreshhold = 10;

////Price samplePrice = new Price(10, Currency.Euro);
//Price samplePrice = new Price() { ItemPrice = 10, Currency = Currency.Euro };

////Product p1 = new Product(1, "Bottle", "Juice", samplePrice, UnitType.PerKg, 200);
//Product p1 = new Product(1)
//{
//    Name = "Bottle",
//    Description = "Juice",
//    Price = samplePrice,
//    UnitType = UnitType.PerItem
//};

//p1.IncreaseStock(10);
//p1.Description = "Sample Description";

//var p2 = new Product(2, "Cap", "Blue", samplePrice, UnitType.PerItem, 5);

//Product p3 = new Product(3, "Mask", "HEPA", samplePrice, UnitType.PerItem, 20);

Utilities1.ShowMainMenu();

Console.WriteLine("Application closing now");

Console.ReadLine();
static void PrintWelcome()
{
    Console.WriteLine("Press enter key to start logging in");
    Console.ReadLine();
    Console.Clear();
}