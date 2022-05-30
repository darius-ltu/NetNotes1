/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetNotes.Book;
using NetNotes.Repositories;
using NetNotes.Services;

namespace NetNotes.Pages.Categor
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CategorRepository _repository;
        private readonly UserService _userService;

        public List<Categories> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchInputTitle { get; set; }

        public IndexModel(CategorRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Categories = _repository.GetCategoriesByUserId(userId);
            Categories = _repository.GetCategories();
            if (!string.IsNullOrEmpty(SearchInputTitle))
            {
                Categories = _repository.GetCategoriesByTitle(SearchInputTitle);
            }
            else
            {
                Categories = _repository.GetCategories();
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            var category = _repository.GetCategories(id);
            if (category == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(id);
            return RedirectToPage("Index");
        }
    }
}
*/