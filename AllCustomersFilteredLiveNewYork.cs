public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var customers = db.Customers
                .Where(i => i.City == "New York")
                .Select(s => new { s.FirstName, s.LastName })
                .ToList();

            foreach (var item in customers)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}