
using AngularApp1.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp1.Server.DataService
{
    public class DataService : AngularApp1.Server.IDataService.IDataService
    {

        private readonly MyDbContext _db;
        public DataService(MyDbContext db)
        {
            _db = db;
        }


        public List<Category> getAllCategories()
        {
            var categories = _db.Categories.ToList(); //get all categories from database
            return categories;
        }

        public Category GetFirstCategory() {

            var category = _db.Categories.First(); //get the first category

            return category;
        }


        public Category GetCategoryById(int id) {

            var category = _db.Categories.Find(id); //find the category by id
            return category;

        }

        public List<Category> GetCategoryByName(string name)
        {
            var category = _db.Categories.Where(c => c.CategoryName == name).ToList(); //find the category by name
            return category;
        }

        public bool DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return true;
            }
            return false;

        }


        //............................................Product.......................................................

        public Product GetProduct(int id)
        {
            var product = _db.Products.Find(id); //find the product by id

            return product;




        }
    }

}
