public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            { 
                var product = db.Products
                    .Where(i => i.Category == "Beverages" || i.Category == "Condiments")
                    .Select(p => new { p.Category, p.ListPrice})
                    .Sum(s=>s.ListPrice);
                
                Console.WriteLine(product);
            }
        }
    }