public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            { 
                var customers = db.Customers.ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.FirstName + " " + customer.LastName);
                }
            }
        }
    }