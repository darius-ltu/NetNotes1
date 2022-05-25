using NetNotes.Areas.Identity.Data;
using NetNotes.Book;

namespace NetNotes.Repositories
{
    public class NotesRepository
    {
        private readonly NetNotesContext _context;

        public NotesRepository(NetNotesContext context)
        {
            _context = context;
        }
        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }
        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes.Where(note => note.NetNotesUserId == id).ToList();
        }
    }
}
