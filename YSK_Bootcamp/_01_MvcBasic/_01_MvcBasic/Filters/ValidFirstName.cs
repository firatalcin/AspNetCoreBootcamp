using Microsoft.AspNetCore.Mvc.Filters;
using MvcBasic.Models;

namespace _01_MvcBasic.Filters
{
    public class ValidFirstName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.FirstOrDefault(x => x.Key == "customer");

            var customer = dictionary.Value as Customer;

            base.OnActionExecuting(context);
        }
    }
}
