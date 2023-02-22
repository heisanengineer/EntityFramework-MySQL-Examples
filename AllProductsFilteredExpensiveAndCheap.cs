public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var product2 = db.Products
                .Min(i => i.ListPrice);

            var product = db.Products
                .Max(i => i.ListPrice);

            Console.WriteLine(product);
            Console.WriteLine(product2);
        }
    }
}