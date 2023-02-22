public class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            var customers = db.Customers.Select(s => new
            {
                s.FirstName,
                s.LastName
            });

            foreach (var Customer in customers)
            {
                Console.WriteLine(Customer.FirstName + " " + Customer.LastName);
            }
        }
    }
}