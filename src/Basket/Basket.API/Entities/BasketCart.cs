using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public BasketCart()
        {
            
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var basketCartItem in Items)
                {
                    totalPrice += basketCartItem.Price * basketCartItem.Quantity;
                }
                return totalPrice;
            }
        }
    }
}
