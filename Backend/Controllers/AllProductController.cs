using Backend.Method;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class AllProductController : Controller
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product);
            return NoContent();
        }
        [HttpPatch("{id}/{name}/{price}")]
        public IActionResult Change(int id, string name, int price)
        {
            Product product = products.Find(p => p.Id == id);
            product.Name = name;
            product.Price = price;
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            product.Id = products.Count > 0 ? products[^1].Id + 1 : 1;
            products.Add(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
        [HttpGet("GetNewitems")]
        public IActionResult GetNewitems()
        {

            CreateNewTwentyItems q = new CreateNewTwentyItems();
            q.AddProduct(products);
            return Ok(products);
        }

        [HttpPost("Filtr")]
        public IActionResult GetFitrList([FromBody] FilterRequest request)
        {
            switch (request.Value)
            {
                case "Ordinary": return Ok(products);
                case "Alphabetically": return Ok(products.OrderBy(x => x.Name).ToList());
                case "PriceUp": return Ok(products.OrderBy(x => x.Price).ToList());
                case "PriceDown": return Ok(products.OrderByDescending(x => x.Price).ToList());
                default: return Ok(products);
            }
        }
    }
}
