using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetNotes.Book;
using NetNotes.Repositories;
using NetNotes.Services;

namespace NetNotes.Pages.Notes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _repository;
        private readonly UserService _userService;

        public List<Note> Notes { get; set; }

        public IndexModel(NotesRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void OnGet()
        {
            var userId = _userService.GetUserId();
            Notes = _repository.GetNotesByUserId(userId);
        }
    }
}
