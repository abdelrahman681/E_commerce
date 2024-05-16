using E_Commerce.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;

namespace E_commerce.API.Helper
{
    public class CashAttribute : Attribute, IAsyncActionFilter
    {
      
        private readonly int _time;
        public CashAttribute(int Time)
        {
            _time = Time;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var CashKey= GenreteKeyFromRequest(context.HttpContext.Request);
            var cashService=context.HttpContext.RequestServices.GetRequiredService<ICashService>();
            var cashResponse = await cashService.GetCashResponseAysnc(CashKey);
            if(cashResponse is not null)
            {
                var result = new ContentResult
                {
                    ContentType = "application/json",
                    StatusCode = 200,
                    Content=cashResponse
                };
                context.Result = result;
                return;
            }
             var executed= await next();
            if (executed.Result is OkObjectResult response)
                await cashService.SetCashResponseAysnc(CashKey, response.Value, TimeSpan.FromSeconds(_time));
        }

        private string GenreteKeyFromRequest(HttpRequest request) 
        { 
            StringBuilder Key = new StringBuilder();
            Key.Append($"{request.Path}");
            foreach (var item in request.Query.OrderBy(K=>K.Key))
            {
                Key.Append($"{item}");
            }

            return Key.ToString();
        }
    }
}
