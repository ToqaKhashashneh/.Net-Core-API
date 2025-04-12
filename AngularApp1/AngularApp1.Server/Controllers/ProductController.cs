using AngularApp1.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly MyDbContext _db; //call to database

        public ProductController(MyDbContext db) //constructor to give inital values (inject for database inside the controller)
        {
            _db = db;
        }


        // all, first, id,name
        [HttpGet("First")]
        public IActionResult GetFirstProduct() //get the first product
        {
            var product = _db.Products.First();
            if (product == null)
            {
                return NotFound(); //if not found, return 404
            }
            return Ok(product); //return the list of products
        }

        [HttpGet]
        public IActionResult GetProducts() //get all products
        {
            var products = _db.Products.ToList(); //get all products from database
            return Ok(products); //return the list of products
        }


        [HttpGet("getproductbyId/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _db.Products.Find(id); //find the product by id
            if (product == null)
            {
                return NotFound(); //if not found, return 404
            }
            return Ok(product); //return the product

        }


        [HttpGet("{Name}")]
        public IActionResult SearchByName(string Name)
        {
            var products = _db.Products.FirstOrDefault(c => c.ProductName == Name); //search for products by name
            if (products == null)
            {
                return NotFound(); //if not found, return 404
            }
            return Ok(products); //return the product
        }
    }

}
