using AngularApp1.Server.Models;
using AngularApp1.Server.Models.Dto;

namespace AngularApp1.Server.IDataService
{
    public interface IDataService
    {
        public List<Category> getAllCategories();

        public Category GetFirstCategory();

        public Category GetCategoryById(int id);

        public List<Category> GetCategoryByName(string name);

        public bool DeleteCategory(int id);

        //public void addCategory(CategoryDto dto);

        public void AddCategory(CategoryDto dto);

        public Category UpdateCategory(int id, CategoryDto dto);


    }
}
