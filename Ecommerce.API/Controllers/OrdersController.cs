using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.OrderEntity;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _order;

        public OrdersController(IOrderService order)
        {
            _order = order;
        }
        [HttpPost]
        public async Task<ActionResult<OrderResultDto>> Create(OrderDto orderDto)
        {
            var order = await _order.CreateOrderAsync(orderDto);
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResultDto>>> GetAllOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order = await _order.GetAllOrderAsync(email);
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<OrderResultDto>> GetOrders(Guid id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order = await _order.GetOrderAsync(id,email);
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethod()
            => Ok(await _order.GetDeliveryMethodsAsync());
    }
}
