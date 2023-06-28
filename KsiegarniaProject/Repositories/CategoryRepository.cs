using KsiegarniaProject.Data;
using KsiegarniaProject.DTO;
using KsiegarniaProject.Interfaces;
using KsiegarniaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(IDataContext context)
        {
            _context = context;
        }
        private readonly IDataContext _context;
        public ICollection<CategoryDTO> GetCategories()
        {
            var categories = _context.Categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            return categories;
        }
        public CategoryDTO GetCategory(int id)
        {
            return _context.Categories.Where(a => a.Id == id).Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).FirstOrDefault();
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(x => x.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool Delete(int id)
        {
            Category temp = _context.Categories.Where(b => b.Id == id).FirstOrDefault();
            _context.Categories.Remove(temp);
            return Save();
        }
        public Category Create(Category c)
        {
            _context.Categories.Add(c);
            Save();
            return c;
        }
        public ICollection<string> GetCategoriesContaining(string term)
        {

            return _context.Categories.Where(c => c.Name.Contains(term)).Select(c => c.Name).ToList();
        }
        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(a => a.Name == name).FirstOrDefault();
        }
    }
}
