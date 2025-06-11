using Microsoft.AspNetCore.Mvc;
using Backend.Model;
using System.Collections.Generic;
using Backend.Method;
using System.Diagnostics;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

    private static List<Product> products = new List<Product>();
    private static List<Product> myProducts = new List<Product>();
    private static decimal balance = 100000;

    public class FilterRequest
    {
        public string Value { get; set; }
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(products);
    }
    [HttpGet("loadmybalance")]
    public IActionResult GetBalance()
    {
        return Ok(balance);
    }
    
    [HttpPost("setBalance")]
    public IActionResult SetBalance([FromBody] FilterRequest product)
    {
        balance = decimal.Parse(product.Value);
        return NoContent();
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
    [HttpGet("GetNewitems")]
    public IActionResult GetNewitems() {

        CreateNewTwentyItems q = new CreateNewTwentyItems();
        q.AddProduct(products);
        return Ok(products);
    } 
    [HttpGet("loadmyproducts")]
    public IActionResult GetMyProducts()
    {
        return Ok(myProducts);
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
    [HttpPost("myproducts")]
    public IActionResult AddMyProducts([FromBody] Product newProduct)
    {
        if (newProduct == null)
            return BadRequest("Дані не отримано!");

        if (string.IsNullOrWhiteSpace(newProduct.Name))
            return BadRequest("Ім'я продукту не може бути порожнім!");

        if (newProduct.Price <= 0)
            return BadRequest("Ціна має бути більшою за 0!");

        if(newProduct.Price > balance)
        {
            return BadRequest("Недостатньо на баласні");
        }
        balance -= newProduct.Price;
        myProducts.Add(newProduct);
        return Ok(myProducts);
    }

}
