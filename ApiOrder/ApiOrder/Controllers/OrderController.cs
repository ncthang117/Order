using ApiOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Xml.Schema;

namespace ApiOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public static List<Order> Orders = new List<Order>();
        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(Orders);
        }
        [HttpPost]
        public IActionResult CreateOrder (Order order)
        {
            var od = new Order
            {
                ID = Guid.NewGuid(),
                UserID = order.UserID,
                ProductID = order.ProductID,
                Quantity = order.Quantity,
                Date = order.Date,
                Total = order.Total,
                Status = order.Status,
            };
            Orders.Add(od);
            return Ok(new { success = true, Data = od}) ;
        }
        [HttpDelete("{ID}")]
        public IActionResult DeleteOrder (string ID)
        {
            try
            {
                var order = Orders.SingleOrDefault(ct => ct.ID == Guid.Parse(ID));
                if (order == null) { return NotFound(); }
                if (ID!= order.ID.ToString())
                {
                    return BadRequest();
                }
                Orders.Remove(order);
                return Ok();
            }
            catch { return BadRequest(); }
        }
        [HttpPut("{ID}")]
        public IActionResult UpdateOrder(string ID , Order orderUpdate)
        {
            try
            {
                var order = Orders.SingleOrDefault(ct => ct.ID == Guid.Parse(ID));
                if (order == null) { return NotFound(); }
                if (ID != order.ID.ToString()) return BadRequest();
                order.UserID = orderUpdate.UserID;
                order.ProductID = orderUpdate.ProductID;
                order.Quantity = orderUpdate.Quantity;
                order.Status = orderUpdate.Status;
                order.Total = orderUpdate.Total;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
