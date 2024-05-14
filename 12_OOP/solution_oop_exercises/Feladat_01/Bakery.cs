public class Bakery
{
    private static List<IPrice> _products = [];

    public static async Task BuyersAsync(string fileName)
    {
        try
        {
            foreach (string line in await File.ReadAllLinesAsync(fileName))
            {
                var parts = line.Split(' ');
                var product = PastryFactory.GetPastryProduct(parts);
                _products.Add(product);
            }
            
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static async Task FoodInventoryAsync()
    {
        try
        {
            var pogacsas = _products.Where(p => p.GetType() == typeof(Scone)).Select(p => p.ToString());

            await File.WriteAllLinesAsync("leltar.txt", pogacsas);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
