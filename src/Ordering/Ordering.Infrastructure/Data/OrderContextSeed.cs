using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContex orderContex, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                orderContex.Database.Migrate();

                if (!orderContex.Orders.Any())
                {
                    orderContex.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContex.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(orderContex, loggerFactory, retryForAvailability);

                }
                throw;
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "oceylan", FirstName = "Omer", LastName = "Ceylan", EmailAddress = "omerceylan@gmail.com",
                    AddressLine = "Atasehir", Country = "Turkey"
                }
            };
        }
    }
}
