using KsiegarniaProject.DTO;
using KsiegarniaProject.Models;
namespace KsiegarniaProject.Interfaces

{
    public interface ICategoryRepository
    {
        ICollection<CategoryDTO> GetCategories();
        CategoryDTO GetCategory(int id);
        bool CategoryExists(int id);
        bool Save();
        bool Delete(int id);
        Category Create(Category c);
        ICollection<string> GetCategoriesContaining(string term);
        Category GetCategoryByName(string name);
    }
}
