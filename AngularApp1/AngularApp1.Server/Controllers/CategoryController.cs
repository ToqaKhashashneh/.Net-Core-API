using System.Reflection.Metadata.Ecma335;
using AngularApp1.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularApp1.Server.IDataService;
using AngularApp1.Server.Models.Dto;
namespace AngularApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AngularApp1.Server.IDataService.IDataService _data; //call to database

        public CategoryController(AngularApp1.Server.IDataService.IDataService data) //constructor to give inital values (inject for database inside the controller)
        {
            _data = data;
        }


        // all, first, id,name


        [HttpGet("First")]
        public IActionResult GetFirstCategory() //get the first category
        {
            var category = _data.GetFirstCategory();
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        [HttpGet]
        public IActionResult GetCategories() //get all categories
        {
            var categories = _data.getAllCategories();

            return Ok(categories);
        }

        [HttpGet("getCategorybyId/{id}")]
        public IActionResult GetCategoryById(int id) //get a specific category
        {
            var category = _data.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);  //inside status accepts obj, variable but not string
        }


        [HttpGet("{Name}")]
        public IActionResult SearchByName(string Name)
        {
            var categories = _data.getAllCategories();

            if (categories == null)
            {
                return NotFound(); //if not found, return 404
            }
            return Ok(categories);

        }


        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _data.DeleteCategory(id);
            if (category == true)
            {

                return NoContent();
            }
            return NotFound();

        }



        //[HttpPost("add")]
        //public IActionResult AddCategory([FromBody] CategoryDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest("Category data is null");
        //    }
        //    _data.addCategory(dto);
        //    return Ok(new { message = "Category added successfully" });
        //}

        [HttpPost("add")]
        public IActionResult AddCategory([FromForm] CategoryDto dto)
        {
            if (dto == null)
             return BadRequest();
            _data.AddCategory(dto);
            return Ok();

        }


        [HttpPut("update/{id}")]
        public IActionResult UpdateCategory(int id, [FromForm] CategoryDto dto)
        {
            if (dto == null )
            return BadRequest("Category data is null");

            var category = _data.UpdateCategory(id, dto);
            return Ok();

            
        }







    }
}
