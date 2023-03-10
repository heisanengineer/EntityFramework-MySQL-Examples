using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleApp2.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql;


namespace ConsoleApp2
{
    public class CustomerDemo
    {
        public CustomerDemo()
        {
            Orders = new List<OrderDemo>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }

        public List<OrderDemo> Orders { get; set; }
    }

    public class OrderDemo
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }

        public List<ProductDemo> Products { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            using (var db = new NorthwindContext())
            {
                var customers = db.Customers
                    .Where(i => i.Orders.Count() > 0) //Any()

                    .Select(i => new CustomerDemo
                    {
                        CustomerId = i.Id,
                        Name = i.FirstName,
                        OrderCount = i.Orders.Count(),
                        Orders = i.Orders.Select(a => new OrderDemo
                        {
                            OrderId = a.Id,
                            Total = (decimal)a.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)
                        }).ToList()
                    })
                    .OrderBy(i => i.OrderCount)
                    .ToList();

                foreach (var item in customers)
                {
                    Console.WriteLine($"id: {item.CustomerId} | Name: {item.Name} | Order Count {item.OrderCount}");
                }

                foreach (var customer in customers)
                {
                    foreach (var order in customer.Orders)
                    {
                        Console.WriteLine($"order id: {order.OrderId} total: {order.Total}");
                    }
                }
            }
        }
    }
}
