public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            { 
                var product = db.Products
                    .Where(i => i.ProductName.Contains("Tea".ToLower()) || i.Description.Contains("Tea".ToLower())).ToList();

                foreach (var item in product)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
        }
    }