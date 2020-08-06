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

        [HttpPost]
        [Route("api/insurance/product")]
        public async Task<ActionResult> CalculateInsurance(CalculateInsurance command)
        {
            var commandResult = await _productHandler.Handle(command);

            if (commandResult.Success == false)
            {
                //TODO: Log here! 

                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(commandResult.Message);
                //return Task.FromResult(response);
            }
            else if (commandResult.Data == null)
                return BadRequest(commandResult.Message);

            return Ok(commandResult.Data);
        }
    }
}