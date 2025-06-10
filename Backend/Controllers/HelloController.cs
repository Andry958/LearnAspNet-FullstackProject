using Microsoft.AspNetCore.Mvc;
using Backend.Model;
using System.Collections.Generic;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new List<Product>();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        if (product == null)
            return BadRequest();

        product.Id = products.Count > 0 ? products[^1].Id + 1 : 1; // інкремент ID
        products.Add(product);

        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // Новий метод видалення
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = products.Find(p => p.Id == id);
        if (product == null)
            return NotFound();

        products.Remove(product);
        return NoContent();
    }
}
