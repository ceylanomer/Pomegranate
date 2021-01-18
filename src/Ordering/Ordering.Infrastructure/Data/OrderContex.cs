using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContex : DbContext
    {
        public OrderContex(DbContextOptions<OrderContex> options): base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
