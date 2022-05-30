/*
using Microsoft.EntityFrameworkCore;
using NetNotes.Areas.Identity.Data;
using NetNotes.Book;
using NetNotes.Services;

namespace NetNotes.Repositories
{
    public class CategorRepository
    {
        private readonly NetNotesContext _context;
        private readonly UserService _service;

        public CategorRepository(NetNotesContext context, UserService service)
        {
            _context = context;
            _service = service;
        }
        public List<Categories> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Categories> GetCategoriesByTitle(string title)
        {
            return _context.Categories.Where(category => category.Title.Contains(title)).ToList();
        }

        public List<Categories> GetCategoriesByUserId(string userId)
        {
            return _context.Categories.Include(ct => ct.Notes).Where(ct => ct.NetNotesUserId == userId).ToList();
        }
        public Categories GetCategories(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public void UpdateCategories(Categories category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            var existingCategories = GetCategories(category.Id);

            if (existingCategories != null)
            {
                _context.Update(category);
                _context.SaveChanges();
            }
        }

        public void CreateCategories(Categories categories)
        {
            categories.NetNotesUserId = _service.GetUserId();
            _context.Categories.Add(categories);
            _context.SaveChanges();
        }
    }
}
*/