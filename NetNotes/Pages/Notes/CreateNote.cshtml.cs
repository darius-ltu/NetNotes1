using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetNotes.Areas.Identity.Data;
using NetNotes.Book;
using NetNotes.Repositories;
using NetNotes.Services;

namespace NetNotes.Pages.Notes
{
    public class CreateNoteModel : PageModel
    {
        private readonly NotesRepository _context;
        private readonly NetNotesContext _service;

        [BindProperty]
        public Note Note { get; set; }

        public CreateNoteModel(NotesRepository context, NetNotesContext service)
        {
            _context = context;
            _service = service;
        }

        public void OnGet(Note note)
        {
        }


        public IActionResult OnPost()
        {
            if (Note.Title == null)
            {
                return Page();
            }

                _context.CreateNote(Note);
                return RedirectToPage("Index");
        }

        /*public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(Note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Page();
            }
        }*/
    }
}
