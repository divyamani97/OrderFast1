using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderFast1.Models;

namespace OrderFast1.DataAccess
{
    public interface IOrderDA
    {
        int AddOrder(Order or);

        int DeleteOrder(int id);

        List<Order> GetOrder();
        
        List<Order> GetOrderById(int id);

        int UpdateOrder(Order or);

    }
}
