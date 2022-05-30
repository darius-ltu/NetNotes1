using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetNotes.Areas.Identity.Data;
using NetNotes.Book;
using NetNotes.Repositories;
using NetNotes.Services;

namespace NetNotes.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly NetNotesContext _service;
        private readonly UserService _userService;

        public EditModel(NotesRepository notesRepository, NetNotesContext service, UserService userService)
        {
            _notesRepository = notesRepository;
            _service = service;
            _userService = userService;
        }
        [BindProperty]
        public Note Note { get; set; }
        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
        }

        public IActionResult OnPost()
        {
            //Note.NetNotesUserId = _userService.GetUserId();
            if (ModelState.IsValid)
            {
                var noteFromDb = _notesRepository.GetNote(Note.Id);
                //noteFromDb.NetNotesUserId = Note.NetNotesUserId;
                noteFromDb.Title = Note.Title;
                noteFromDb.Content = Note.Content;
                _notesRepository.UpdateNote(noteFromDb);
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
