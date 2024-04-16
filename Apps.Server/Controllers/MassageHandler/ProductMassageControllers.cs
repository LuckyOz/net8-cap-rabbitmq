
using DotNetCore.CAP;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Apps.Server.Controllers.MassageHandler
{
    public class ProductMassageControllers(ILogger<ProductMassageControllers> logger) : ControllerBase
    {
        [NonAction]
        [CapSubscribe("product")]
        public async Task ProductMessageHandler(string value)
        {
            logger.LogInformation("Product Message Received: {product}", value);
        }
    }
}
