using Microsoft.AspNetCore.Mvc;
using static Backend.Controllers.AllProductController;
using static Backend.Controllers.MyProductController;
using Backend.Model;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class BalanceController : Controller
    {
        private static decimal balance = 100000;


        [HttpGet]
        public IActionResult GetBalance()
        {
            return Ok(balance);
        }

        [HttpPost]
        public IActionResult SetBalance([FromBody] FilterRequest product)
        {
            balance = decimal.Parse(product.Value);
            return NoContent();
        }
    }
}
