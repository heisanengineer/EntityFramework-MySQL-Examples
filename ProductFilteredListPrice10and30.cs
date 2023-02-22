public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var product = db.Products
                .Where(i => i.ListPrice < 30 && i.ListPrice > 10)
                .Select(p => new { p.ListPrice, p.ProductName }).ToList();

            foreach (var item in product)
            {
                Console.WriteLine(item.ProductName + " = " + item.ListPrice);
            }
        }
    }
}