using E_commerce.API.Errors;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Entity.NewFolder;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Domain.Specification;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServices _basket;

        public BasketController(IBasketServices basket)
        {
            _basket = basket;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> GetBasket(string id)
        {
            var bsket = await _basket.GetBasketAsync(id);
            return bsket is not null ? Ok(bsket) : NotFound(new API_Response(404, $"The basket with this id {id} not Found"));
        }
        [HttpDelete]
        public async Task<ActionResult<CustomerBasketDto>> DeleteBasket(string id)
        {
            var deleteBasket=await _basket.DeletBasketAsync(id);
            return Ok(deleteBasket);
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basket)
        {
            var UpdateBasket = await _basket.UpdateBasketAsync(basket);
            return UpdateBasket is not null ? Ok(UpdateBasket) : NotFound(new API_Response(404, $"The basket with this id {basket.Id} not Found"));
        }
    }
}
