using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PayMentController : ControllerBase
    {
        private readonly IPayService _payService;
        private readonly IConfiguration _con;
        const string endpointSecret = "whsec_05582f2e22fd14271ab542e08f2d8eb3e218dd0e97cdb033b62d52db7a0d41fe";

        public PayMentController(IPayService payService, IConfiguration con)
        {
            _payService = payService;
            _con = con;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> CreatePayMent(CustomerBasketDto basketDto)
        {
            var basket = await _payService.CreateOrUpdatepayforeExistorder(basketDto);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                // Handle the event
                if (stripeEvent.Type == Events.PaymentIntentPaymentFailed)
                {
                    var payment= stripeEvent.Data.Object as PaymentIntent;
                    await _payService.UpdatePayStatusesFaild(payment.Id);
                }
                else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var payment = stripeEvent.Data.Object as PaymentIntent;
                    await _payService.UpdatePayStatusesSucsed(payment.Id);
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}

