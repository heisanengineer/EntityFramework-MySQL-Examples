public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var product = db.Products
                .Where(i => i.Category == "Beverages")
                .Select(s => new { s.ProductName })
                .ToList();

            foreach (var p in product)
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}