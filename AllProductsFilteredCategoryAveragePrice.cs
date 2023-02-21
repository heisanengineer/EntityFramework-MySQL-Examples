public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            { 
                var product = db.Products
                    .Where(i => i.Category == "Beverages")
                    .Select(p => new { p.Category, p.ListPrice })
                    .Average(a => a.ListPrice);
                
                Console.WriteLine(product);
            }
        }
    }