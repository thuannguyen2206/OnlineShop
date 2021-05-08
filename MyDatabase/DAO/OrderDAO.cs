using MyDatabase.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDatabase.DAO
{
    public class OrderDAO
    {
        OnlineShop db = null;
        public OrderDAO()
        {
            db = new OnlineShop();
        }

        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.id;
        }

    }
}
