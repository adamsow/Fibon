using System.Threading.Tasks;
using Fibon.Api.FibbonRepository;
using Fibon.Messages;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient _busCient;
        private readonly IRepository _repository;
        
        public FibonacciController(IBusClient busClient, IRepository fibonRepository)
        {
            _busCient = busClient;
            _repository = fibonRepository;
        }
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? calculatedValue = _repository.Get(number);
            if (calculatedValue.HasValue)
            {
                return Content(calculatedValue.ToString());
            }

            return NotFound();
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? calculatedValue = _repository.Get(number);
            if (!calculatedValue.HasValue)
            {
                await _busCient.PublishAsync(new CalculateValueCommand(number));
            }

            return Accepted($"fibonnacci/{number}", null);
        }
    }
}