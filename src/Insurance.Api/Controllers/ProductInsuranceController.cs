using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Insurance.Domain.Commands;
using Insurance.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Api.Controllers
{
    public class ProductInsuranceController : Controller
    {
        private ProductHandler _productHandler;

        public ProductInsuranceController(ProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        [HttpGet]
        [Route("api/insurance/product")]
        public async Task<ActionResult> CalculateInsurance(CalculateInsurance command)
        {
            var commandResult = await _productHandler.Handle(command);

            if (commandResult.Success == false)
                return StatusCode(500, commandResult.Message);

            else if (commandResult.Data == null)
                return BadRequest(commandResult.Message);

            return Ok(commandResult.Data);
        }
    }
}