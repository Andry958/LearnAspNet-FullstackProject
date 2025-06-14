//using Backend.Method;
//using Backend.Model;
//using Microsoft.AspNetCore.Mvc;


//namespace Backend.Controllers
//{
//    [ApiController]
//    [Route("api/products")]
//    public class AllProductController : Controller
//    {
//        private static List<Product> products = new List<Product>();
//        private ProductDb _workWithServer;

//        public AllProductController(ProductDb workWithServer)
//        {
//            _workWithServer = workWithServer;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(_workWithServer.Products);
//        }
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var product = _workWithServer.Products.FirstOrDefault(p => p.Id == id);
//            if (product == null)
//                return NotFound();

//            _workWithServer.Products.Remove(product); 
//            _workWithServer.SaveChanges();

//            return NoContent();
//        }
//        [HttpPatch("{id}/{name}/{price}")]
//        public IActionResult Change(int id, string name, int price)
//        {
//            var product = _workWithServer.Products.FirstOrDefault(p => p.Id == id);
//            if (product == null)
//                return NotFound();

//            product.Name = name;
//            product.Price = price;

//            _workWithServer.SaveChanges();

//            return Ok(_workWithServer.Products.ToList());
//        }
//        public class UpdateProductRequest
//        {
//            public string Name { get; set; }
//            public int Price { get; set; }
//        }
//        [HttpPost]
//        public IActionResult Post([FromBody] Product product)
//        {
//            if (product == null)
//                return BadRequest();
//            _workWithServer.Products.Add(product);
//            _workWithServer.SaveChanges();
//            return CreatedAtAction(nameof(Get), _workWithServer.Products.ToList());
//        }
//        [HttpGet("GetNewitems")]
//        public IActionResult GetNewitems()
//        {

//            CreateNewTwentyItems q = new CreateNewTwentyItems(_workWithServer);
//            q.AddProduct(products);
//            return Ok(_workWithServer.Products.ToList());
//        }

//        [HttpPost("Filtr")]
//        public IActionResult GetFitrList([FromBody] FilterRequest request)
//        {
//            switch (request.Value)
//            {
//                case "Ordinary": return Ok(_workWithServer.Products.ToList());
//                case "Alphabetically": return Ok(_workWithServer.Products.ToList().OrderBy(x => x.Name).ToList());
//                case "PriceUp": return Ok(_workWithServer.Products.ToList().OrderBy(x => x.Price).ToList());
//                case "PriceDown": return Ok(_workWithServer.Products.ToList().OrderByDescending(x => x.Price).ToList());
//                default: return Ok(_workWithServer.Products.ToList());
//            }
//        }
//    }
//}
//-------------------------------------------------------------
using Backend.Method;
using Backend.Model;
using Backend.Model.WorkWhitServer;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class AllProductController : Controller
    {
        private WorkWithServer _server;
        //private ProductDb _workWithServer;

        public AllProductController(ProductDb workWithServer)
        {
            _server = new WorkWithServer(workWithServer);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_server.GetProducts());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _server.Delete(id);

            return NoContent();
        }
        [HttpPatch("{id}/{name}/{price}")]
        public IActionResult Change(int id, string name, int price)
        {
            _server.Update(id, name, price);

            return Ok(_server.GetProducts());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _server.Add(product);
            return CreatedAtAction(nameof(Get), _server.GetProducts());
        }
        [HttpGet("GetNewitems")]
        public IActionResult GetNewitems()
        {

            _server.CreateNewItems();
            return Ok(_server.GetProducts());
        }

        [HttpPost("Filtr")]
        public IActionResult GetFitrList([FromBody] FilterRequest request)
        {
           return Ok(_server.Filtr(request.Value));
        }
    }
}
