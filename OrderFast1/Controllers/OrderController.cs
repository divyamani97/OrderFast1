using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFast1.DataAccess;
using OrderFast1.Models;

namespace OrderFast1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderDA orderDA = new OrderDA();

        [HttpGet]
        [Route("get")]
        public List<Order> Get()
        {
            return orderDA.GetOrder();
        }

        [HttpGet]
        [Route("get/{id}")]
        public List<Order> GetById(int id)
        {
            return orderDA.GetOrderById(id);
        }
        [HttpPost]
        [Route("insert")]
        public int insert(Order or)
        {
            return orderDA.AddOrder(or);
        }

        [HttpDelete]
        [Route("delete")]
        public int Delete(int id)
        {
            return orderDA.DeleteOrder(id);
        }
        [HttpPut]
        [Route("update")]
        public int Update(Order or)
        {
            return orderDA.UpdateOrder(or);
        }

    }
}
