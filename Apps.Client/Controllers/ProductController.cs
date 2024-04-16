
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Apps.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ICapPublisher capPublisher, ILogger<ProductController> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        [HttpPost("add_product")]
        public async Task<IActionResult> AddProduct()
        {
            await _capPublisher.PublishAsync("sample.product", DateTime.Now);
            return Ok();
        }

        [HttpPost("add_product_test")]
        public async Task<IActionResult> AddProductTest()
        {
            await _capPublisher.PublishAsync("sample.product.test", "test");
            return Ok();
        }

        [NonAction]
        [CapSubscribe("sample.product")]
        public void ProductMessageHandler(DateTime time)
        {
            Console.WriteLine("Publishing time:" + time);
        }

        [NonAction]
        [CapSubscribe("sample.product.test")]
        public void ProductTestMessageHandler(string test)
        {
            Console.WriteLine("Publishing time:" + test);
        }
    }
}
