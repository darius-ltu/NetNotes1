using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetNotes.Areas.Identity.Data;
using NetNotes.Book;
using NetNotes.Services;

namespace NetNotes.Repositories
{
    public class NotesRepository
    {
        private readonly NetNotesContext _context;
        private readonly UserService _service;

        public NotesRepository(NetNotesContext context, UserService service)
        {
            _context = context;
            _service = service;
        }
        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }

        public List<Note> GetNotesByTitle(string title, string userId)
        {
           return _context.Notes.Where(note => note.Title.Contains(title) && note.NetNotesUserId == userId).ToList();
        }

        public List<Note> GetNotesByUserId(string id)
        {
            return _context.Notes.Where(note => note.NetNotesUserId == id).ToList();
        }
        public Note GetNote (int id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }
        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(b => b.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }
        public void UpdateNote(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            var existingNote = GetNote(note.Id);
           
            if (existingNote != null)
            {
                _context.Update(note);
                _context.SaveChanges();
            }
        }

        public void CreateNote(Note note)
        {
            note.NetNotesUserId = _service.GetUserId();
            _context.Notes.Add(note);
            _context.SaveChanges();
        }
    }
}
