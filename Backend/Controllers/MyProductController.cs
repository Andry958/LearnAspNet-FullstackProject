using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/myproducts")]
    public class MyProductController : Controller
    {
        private static List<Product> myProducts = new List<Product>();
        private static decimal balance = 100000;


        [HttpGet]
        public IActionResult GetMyProducts()
        {
            return Ok(myProducts);
        }
        [HttpPost]
        public IActionResult AddMyProducts([FromBody] Product newProduct)
        {
            if (newProduct == null)
                return BadRequest("Дані не отримано!");

            if (string.IsNullOrWhiteSpace(newProduct.Name))
                return BadRequest("Ім'я продукту не може бути порожнім!");

            if (newProduct.Price <= 0)
                return BadRequest("Ціна має бути більшою за 0!");

            if (newProduct.Price > balance)
            {
                return BadRequest("Недостатньо на баласні");
            }
            balance -= newProduct.Price;
            myProducts.Add(newProduct);
            return Ok(myProducts);
        }
    }
}
