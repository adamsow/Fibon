using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient _busCient;
        public FibonacciController(IBusClient busClient)
        {
            _busCient = busClient;
        }
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            return Content($"{number}");
        }

        [HttpPost("{number}")]
        public IActionResult Post(int number)
        {
            return Accepted($"fibonnacci/{number}", null);
        }
    }
}