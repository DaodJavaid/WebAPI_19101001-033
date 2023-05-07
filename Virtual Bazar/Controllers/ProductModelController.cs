using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virtual_Bazar.Data;
using Virtual_Bazar.Models;

namespace Virtual_Bazar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductModelController : Controller
    {

        private readonly ProductDbContext _productDbContext;

        public ProductModelController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpPut("Add/{id}/{name}/{Description}")]
        public IActionResult PutData(ProductModel product, int id, string name, string Description)
        {
            // Validate the model if necessary
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = id;
            product.Name = name;
            product.Description = Description;

            // Save the data to the database
            _productDbContext.Product_Detail.Add(product);
            _productDbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            // Retrieve data from the database
            var data = _productDbContext.Product_Detail.ToList();

            return Ok(data);
        }


    }
}
