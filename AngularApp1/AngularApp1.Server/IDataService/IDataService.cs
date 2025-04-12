using AngularApp1.Server.Models;

namespace AngularApp1.Server.IDataService
{
    public interface IDataService
    {
        public List<Category> getAllCategories();

        public Category GetFirstCategory();

        public Category GetCategoryById(int id);

        public List<Category> GetCategoryByName(string name);

        public bool DeleteCategory(int id);



    }
}
