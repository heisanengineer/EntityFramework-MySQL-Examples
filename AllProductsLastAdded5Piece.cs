public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var product = db.Products.OrderByDescending(i => i.Id).Take(5);

            foreach (var p in product)
            {
                Console.WriteLine(p.ProductName);
            }
        }
    }
}